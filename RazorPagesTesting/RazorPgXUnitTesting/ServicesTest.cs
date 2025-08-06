using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RazorPagesTesting.Pages;
using RazorPagesTesting.Repository;

namespace RazorPgXUnitTesting
{
    public class ServicesTest
    {
        [Fact]
        public void Services_ReturnsList()
        {
            var expected = new List<Service>
            {
                new Service{Name ="Test1", Price=100,Duration= 60},
                new Service{Name="Test2",Price=200,Duration=80   }
            };

            var mockService = new Mock<IService>();
            mockService.Setup(s => s.GetAllServices()).Returns(expected);
            var mod = new ServiceListModel(mockService.Object);
            mod.OnGet();
            Assert.Equal(expected, mod.services);
            mockService.Verify(s=> s.GetAllServices(),Times.Once);
        }
    }
}
