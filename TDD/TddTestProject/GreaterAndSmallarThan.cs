using Xunit;
using TDD;

namespace TddTestProject
{
    public class GreaterAndSmallarThan
    {
        private const bool ExpectedTrue = true;
        private const bool ExpectedFalse = false;

        [Fact]
        public void LessThanOperator_Time1LessThanTime2_ReturnsTrue()
        {
            // Arrange
            Time time1 = new Time(12, 30, 0);
            Time time2 = new Time(15, 0, 0);

            // Act
            bool result = time1 < time2;

            // Assert
            Assert.Equal(ExpectedTrue, result);
        }

        [Fact]
        public void LessThanOperator_Time1EqualsTime2_ReturnsFalse()
        {
            // Arrange
            Time time1 = new Time(12, 30, 0);
            Time time2 = new Time(12, 30, 0);

            // Act
            bool result = time1 < time2;

            // Assert
            Assert.Equal(ExpectedFalse, result);
        }

        [Fact]
        public void LessThanOperator_Time1GreaterThanTime2_ReturnsFalse()
        {
            // Arrange
            Time time1 = new Time(14, 0, 0);
            Time time2 = new Time(12, 30, 0);

            // Act
            bool result = time1 < time2;

            // Assert
            Assert.Equal(ExpectedFalse, result);
        }

        [Fact]
        public void GreaterThanOperator_Time1LessThanTime2_ReturnsTrue()
        {
            // Arrange
            Time time1 = new Time(12, 30, 01);
            Time time2 = new Time(12, 30, 00);

            // Act
            bool result = time1 > time2;

            // Assert
            Assert.Equal(ExpectedTrue, result);
        }

        [Fact]
        public void GreaterThanOp_Time1GreaterThanTime2_ReturnsFalse()
        {
            // Arrange
            Time time1 = new Time(12, 30, 00);
            Time time2 = new Time(14, 45, 00);

            // Act
            bool result = time1 > time2;

            // Assert
            Assert.Equal(ExpectedFalse, result);
        }
        public void ComparisonOperator_Time1EqualsTime2_ReturnsFalse()
        {
            // Arrange
            Time time1 = new Time(12, 30, 0);
            Time time2 = new Time(12, 30, 0);

            // Act
            bool result = time1 != time2;

            // Assert
            Assert.False(result);
        }
    }
}
