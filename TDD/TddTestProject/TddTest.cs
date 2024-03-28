using TDD;
using Xunit;

namespace TddTestProject
{
    /// <summary>
    /// 1. en röd test först.
    /// 2. fixa en metod IsValid och där fick grjode vi en kontroll först för timmerna  om timmerna som vi förväntar oss är 
    /// mindre än 23 eller inte. om de t.ex. -13, vi fick grön test.
    /// 3. vi fick röd test eftersom minuterna kunde vara - och kunde vara mer än 60. 
    /// 4. fixa en kontroll för minuterna, så att de inte är minus eller mer än 60. fick en röd test eftersom det blev inte t.ex. 13:00:00
    /// 5. minskade minuterna till 59 så att det börjar med ett nytt klock slag efter 59, vi fick en grön test. 
    /// </summary>
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
