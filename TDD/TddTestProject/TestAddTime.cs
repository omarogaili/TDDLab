using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD;

namespace TddTestProject
{ /// <summary>
/// i den klassen så testa vi om Addera tid fungerar som det ska
/// vad vi har gjort är att vi skapade de förväntade resultaten som vi vill att metoden ska skicka tillbaka 
/// efter det så enligt kraven då ska vi öka värdet med 1 (++) det vad vi tänkte på är att vi skapar en Time operator ++ där vi kan bestämma hur mycket
/// värdet ska öka samt från vilket håll vill vi lägga till värdet och det var enligt kraven från sekunderna , men vi möts på ett problem och det är att om klockan 
/// är 13:40:59 så om vi lägger en sekund till blir klockan 13:40:01 och detta är inte att den öka så vad vi gjorde att vi hade en lagt en if sats om sekunderna är
/// 59 så ska tiden det läggs till 1 till minuterna och sedan till sekundern och samma sak om minuterna är också 59 då ökar timmerna också. som vi har i här i det fallet
/// [InlineData(23, 59, 59, ExpectedFormat3)]
    /// 
    /// </summary>
    public class TestAddTime
    {
        private const string ExpectedFormat1 = "13:00:02";
        private const string ExpectedFormat2 = "10:01:00";
        private const string ExpectedFormat3 = "00:00:00";

        [Theory]
        [InlineData(13, 0, 1, ExpectedFormat1)] 
        [InlineData(10, 0, 59, ExpectedFormat2)] 
        [InlineData(23, 59, 59, ExpectedFormat3)]
        public void TestIncrementOperator(int hours, int minuter, int sekunder, string expected)
        {
            // Arrange
            Time time = new Time(hours, minuter, sekunder);

            // Act
            Time result = ++time;

            // Assert
            Assert.Equal(expected, result.CovertToString(true)); 
        }

    }

}

