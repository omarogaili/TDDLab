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
    /// 1. en röd test först.
    /// 2. vi tänkter att retunerar en string antegen för eller eftermiddag.
    /// 3. vi fick en grön test för att metoden retunerar string och det som vi förväntar oss är en string som säger "förmiddag"
    /// 4. vi fixar en if stats som kontrollerar om klockan är 12 så ska vi retunerar förmiddag annars så ska det vara eftermiddag.
    /// 5. Grön test
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
