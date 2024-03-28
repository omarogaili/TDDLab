using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD;
using Xunit;

namespace TddTestProject
{
    /// <summary>
    /// vi tänkte att det som vi vill visa är en string som säger om det är för/eftermeddag och detta gjorde vi genom att gav det förväntade resultet
    /// sedan fixade vi en metode som ska retunerar detta och det är IsAm() för att vi ska veta om tiden är för/eftermeddag då behöver vi kontrollera om timmen är
    /// efter 12 på dag innan 12 lunch tid alltså då ska vi få det meddelandet metoden måste ta in timmerna 
    /// </summary>
    public class GetIsAmTested
    {
        private const string ExpectedMorningMessage = "Det är förmiddag";
        private const string ExpectedAfternoonMessage = "Det är eftermiddag";
        [Theory]
        [InlineData(13, 0, 0, ExpectedAfternoonMessage)]
        [InlineData(10, 0, 0, ExpectedMorningMessage)]
        [InlineData(20, 0, 0, ExpectedAfternoonMessage)]
        public void GetTheConvertMethodTested(int hours, int minuter, int sekunder, string expected)
        {
            Time sub = new Time(hours, minuter, sekunder);
            var result = sub.IsAm(hours);
            Assert.Equal(expected, result);
        }

    }
}
