using NUnit.Framework;
using p = CashFlowin.Models.Period;
using static CashFlowin.Models.Date;
using CashFlowin.Models;

namespace CashFlowin.UnitTests
{
    class YearlyItemTest
    {
        private readonly p TestYear = p.Create(Create(2021, 1, 1), Create(2021, 12, 31));
        private readonly Date LastDayOfYear = Create(2021, 12, 31);
        private readonly Date FirstDayOfNormalYear = Create(2021, 01, 01);
        private readonly Date FourthOfJuly = Create(2021, 7, 4);
        private readonly Date LeapDay = Create(2020, 2, 29);
        private readonly Date FirstDayOfLeapYear = Create(2020, 01, 01);

        [Test]
        public void TestNextFourthOfJulyAtStartOfYear()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new YearlyReoccuringItem(new MonthDay(FourthOfJuly), 1, TestYear, testValueItem);

            //Act
            var result = testItem.Next(FirstDayOfNormalYear);

            // Assert
            Assert.AreEqual(Create(2021, 7, 4).Value, result.Value);
        }
        [Test]
        public void TestNextFourthOfJulyAtEndOfYear()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new YearlyReoccuringItem(new MonthDay(FourthOfJuly), 1, TestYear, testValueItem);

            //Act
            var result = testItem.Next(LastDayOfYear);

            // Assert
            Assert.AreEqual(Create(2022, 7, 4).Value, result.Value);
        }
        [Test]
        public void TestLeapDayInLeapYear()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new YearlyReoccuringItem(new MonthDay(LeapDay), 1, TestYear, testValueItem);

            //Act
            var result = testItem.Next(FirstDayOfLeapYear);

            // Assert
            Assert.AreEqual(Create(2020,2, 29).Value, result.Value);
        }
        [Test]
        public void TestLeapDayInNormalYear()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new YearlyReoccuringItem(new MonthDay(LeapDay), 1, TestYear, testValueItem);

            //Act
            var result = testItem.Next(FirstDayOfNormalYear);

            // Assert
            Assert.AreEqual(Create(2021, 2, 28).Value, result.Value);
        }
    }
}