using TDD;
using Xunit;

namespace TddTestProject
{
    public class TddTest
    {
        [Theory]
        [InlineData(0, 0, 0, true)]
        [InlineData(23, 59, 59, true)]
        [InlineData(24, 0, 0, false)]
        [InlineData(12, 60, 0, false)]
        [InlineData(12, 0, 60, false)]
        [InlineData(-1, 30, 30, false)]
        [InlineData(23, 59, -1, false)]

        public void GetTheTimeCheckedIfItIsVaild(int hours, int minutes, int seconds, bool expectedResult)
        {
            //arrange
            
           // act
                var result = Time.IsVaild(hours,minutes,seconds);
            //Assert
                Assert.Equal(expectedResult, result);
        }
    }
}
