using SPASpot;
using Xunit;
using System.Linq;

namespace SpaXUnitTesting
{
    public class SpaTests
    {
        private SpaMain spa;
        public SpaTests()
        {
            spa = new SpaMain();
            spa.ClearServices();
        }
        [Fact]
        public void Add_MultipleServices()
        {
            spa.AddService("Facial", 1200, 45);
            spa.AddService("Massage", 1800, 60);
            spa.AddService("Hair Spa", 1500, 50);
            spa.AddService("Manicure", 800, 25);

            var services = spa.GetAllServices();
            Assert.Equal(4, services.Count);
        }

        [Theory]
        [InlineData(2)]
        public void AddServices_Repeated(int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                spa.ClearServices(); 
                spa.AddService("Facial", 1200, 45);
                var all = spa.GetAllServices();

                Assert.Equal(1, all.Count);
                Assert.Equal("Facial", all[0].ServiceName);
                Assert.Equal(1200, all[0].Price);
            }
        }
        [Fact]
        public void UpdateServicePrice()
        {
            spa.AddService("Massage", 1800, 60);
            spa.UpdateServicePrice("Massage", 1500);

            var service = spa.GetAllServices().FirstOrDefault(s => s.ServiceName == "Massage");
            Assert.Equal(1500, service.Price);
        }
        [Fact]
        public void UpdateServicePriceNegative()
        {
            spa.AddService("Facial", 1200, 45);
            var ex = Assert.Throws<ArgumentException>(() => spa.UpdateServicePrice("Facial", -500));
            Assert.Equal("Price cannot be negative.", ex.Message);
        }

        [Fact]
        public void UpdateServicePrice_NotFound()
        {
            var ex = Assert.Throws<Exception>(() => spa.UpdateServicePrice("NonExistent", 1000));
            Assert.Equal("Service not found.", ex.Message);
        }
        [Fact]
        public void DeleteService()
        {
            spa.AddService("Massage", 1800, 60);
            bool deleted = spa.DeleteService("Massage");

            Assert.True(deleted);
            Assert.Equal(0, spa.GetAllServices().Count);
        }

        [Fact]
        public void AddMultipleServices()
        {
            spa.AddService("Hair spa", 1500, 50);
            spa.AddService("Manicure", 800, 25);
            var all = spa.GetAllServices();

            Assert.Equal(2, all.Count);
            Assert.Contains(all, s => s.ServiceName == "Hair spa");
            Assert.Contains(all, s => s.ServiceName == "Manicure");
        }

        [Theory]
        [InlineData("Facial", 1200, 45)]
        [InlineData("Massage", 1800, 60)]
        public void AddByParameter(string name, int price, int duration)
        {
            spa.AddService(name, price, duration);
            var all = spa.GetAllServices();

            Assert.Single(all);
            Assert.Equal(name, all[0].ServiceName);
            Assert.Equal(price, all[0].Price);
            Assert.Equal(duration, all[0].Duration);
        }
    }
}
