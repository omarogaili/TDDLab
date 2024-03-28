using TDD;
using Xunit;

namespace TddTestProject
{
    /// <summary>
    /// 1. en r�d test f�rst.
    /// 2. fixa en metod IsValid och d�r fick grjode vi en kontroll f�rst f�r timmerna  om timmerna som vi f�rv�ntar oss �r 
    /// mindre �n 23 eller inte. om de t.ex. -13, vi fick gr�n test.
    /// 3. vi fick r�d test eftersom minuterna kunde vara - och kunde vara mer �n 60. 
    /// 4. fixa en kontroll f�r minuterna, s� att de inte �r minus eller mer �n 60. fick en r�d test eftersom det blev inte t.ex. 13:00:00
    /// 5. minskade minuterna till 59 s� att det b�rjar med ett nytt klock slag efter 59, vi fick en gr�n test. 
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
