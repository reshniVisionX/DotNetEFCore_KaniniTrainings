using SPASpot;
using System.Security.Cryptography;

namespace SpaNUnitTesting
{
    public class Tests
    {
        private SpaMain spa;

        [SetUp]
        public void Setup()
        {
            spa = new SpaMain();
            spa.ClearServices();
        }

        [Test, Repeat(3)]
        public void AddServices()
        {
            spa.AddService("Facial", 1200, 45);
            var all = spa.GetAllServices();

            Assert.AreEqual(1, all.Count);
            Assert.AreEqual("Facial", all[0].ServiceName);
            Assert.AreEqual(1200, all[0].Price);
        }
        [Test]
        public void DeleteService()
        {
            spa.AddService("Massage", 1800, 60);
            bool deleted = spa.DeleteService("Massage");

            Assert.IsTrue(deleted);
            Assert.AreEqual(0, spa.GetAllServices().Count);
        }

        [Test]
        public void AddMultiple()
        {
            spa.AddService("Hair spa", 1500, 50);
            spa.AddService("Manicure", 800, 25);
            var all = spa.GetAllServices();
            Assert.AreEqual(2, all.Count);
            Assert.IsTrue(all.Any(s => s.ServiceName == "Hair spa"));
            Assert.IsTrue(all.Any(s => s.ServiceName == "Manicure"));
        }

        [TestCase("Facial", 1200, 45)]
        [TestCase("Massage", 1800, 60)]
        public void AddByParameter(string name, int price, int duration)
        {
            spa.AddService(name, price, duration);
            var all = spa.GetAllServices();

            Assert.AreEqual(1, all.Count);
            Assert.AreEqual(name, all[0].ServiceName);
            Assert.AreEqual(price, all[0].Price);
            Assert.AreEqual(duration, all[0].Duration);
        }

    }
}