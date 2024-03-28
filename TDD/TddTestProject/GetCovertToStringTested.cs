using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD;
using Xunit;


namespace TddTestProject
{

    public class GetCovertToStringTested
    {
        private const string Expected24HourFormat1 = "13:23:01";
        private const string Expected12HourFormat1 = "01:23:01 PM";

        private const string Expected24HourFormat2 = "02:34:01";
        private const string Expected12HourFormat2 = "02:34:01 AM";

        private const string Expected24HourFormat3 = "14:08:00";
        private const string Expected12HourFormat3 = "02:08:00 PM";

        private const string Expected24HourFormat4 = "23:23:23";
        private const string Expected12HourFormat4 = "11:23:23 PM";
        [Theory]
        //CovnertTest
        [InlineData(13, 23, 1, true, Expected24HourFormat1)]
        [InlineData(2, 34, 1, false, Expected12HourFormat2)]
        [InlineData(14, 8, 0, false, Expected12HourFormat3)]
        [InlineData(23, 23, 23, true, Expected24HourFormat4)]
        public void GetTheConvertMethodTested(int hours, int minutes, int seconds, bool convertbool, string expected)
        {
            Time sub = new Time(hours, minutes, seconds);
            var result = sub.CovertToString(convertbool,hours);
            Assert.Equal(expected, result);
        }
    }
}
