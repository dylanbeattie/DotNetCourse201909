using System;
using Xunit;

namespace HonestCars.UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(1,2,3)]
        [InlineData(0,0,0)]
        
        public void Add(int x, int y, int z) {

            // Arrange
            var c= new CalculatorService();
            // Act
            var result = c.Add(x,y);
            // Assert 
            Assert.Equal(result, z);
        }
    }

    public class CalculatorService {
        public int Add(int x, int y) {
            return x + y;
        }
    }
}
