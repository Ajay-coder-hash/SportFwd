using SportFwd.Service;
using Xunit;

namespace SportFwd.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            int result = calc.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }
    }
}
