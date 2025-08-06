using Moq;
using RazorPagesTesting.Pages;

namespace RazorPgXUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void CallsAddAndSetsResult()
        {
            // Arrange
            var mockService = new Mock<RazorPagesTesting.Repository.ICalculator>();
            mockService.Setup(s => s.Add(3, 4)).Returns(7);

            var model = new CalculatorModel(mockService.Object);

            // Act
            model.OnGet(3, 4);

            // Assert
            Assert.Equal(7, model.Result);
            mockService.Verify(s => s.Add(3, 4), Times.Once);
        }
    }
}

