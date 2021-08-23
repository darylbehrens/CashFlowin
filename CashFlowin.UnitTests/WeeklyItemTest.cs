using NUnit.Framework;
using System;
using p = CashFlowin.Models.Period;
using static CashFlowin.Models.Date;
using CashFlowin.Models;
using System.Linq;

namespace CashFlowin.UnitTests
{
    class WeeklyItemTest
    {
        private readonly p TestYear = p.Create(Create(2021, 1, 1), Create(2021, 12, 31));
        private readonly p TestYearMinusOneDay = p.Create(Create(2021, 1, 2), Create(2021, 12, 31));

        [Test]
        public void TestEveryFriday()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new WeeklyReoccuringItem(DayOfWeek.Friday, 1, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYear);

            // Assert
            // There were 53 Fridays in 2021
            Assert.AreEqual(53, result.Values.Count);
            result.Keys.ToList().ForEach(x => Assert.True(x.Value.DayOfWeek == DayOfWeek.Friday));
            Assert.AreEqual(530, result.Values.Sum(x => x.Value));
        }

        [Test]
        public void TestEveryOtherFriday()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new WeeklyReoccuringItem(DayOfWeek.Friday, 2, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYear);

            // Assert
            // There were 53 Fridays in 2021 and half is 27 as the 1st was a Friday
            Assert.AreEqual(27, result.Values.Count);

            // First Friday should be the First of the year
            Assert.AreEqual(Create(2021, 01, 01).Value, result.Keys.First().Value);
            result.Keys.ToList().ForEach(x => Assert.True(x.Value.DayOfWeek == DayOfWeek.Friday));
            Assert.AreEqual(270, result.Values.Sum(x => x.Value));
        }

        [Test]
        public void TestEveryOtherStartingOnSecondFriday()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new WeeklyReoccuringItem(DayOfWeek.Friday, 2, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYearMinusOneDay);

            // Assert
            // There were 53 Fridays in 2021 and since we are skipping first Friday
            Assert.AreEqual(26, result.Values.Count);

            // First Friday should be the Jan 15th, as we skipped the First of the year, and it is Bi-Weekly starting on that First Friday
            Assert.AreEqual(Create(2021, 01, 15).Value, result.Keys.First().Value);
            result.Keys.ToList().ForEach(x => Assert.True(x.Value.DayOfWeek == DayOfWeek.Friday));
            Assert.AreEqual(260, result.Values.Sum(x => x.Value));
        }

        public void TestBiWeeklyStartingOnSecondFriday()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new BiweeklyReoccuringItem(DayOfWeek.Friday, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYearMinusOneDay);

            // Assert
            // There were 53 Fridays in 2021 and since we are skipping first Friday, t
            Assert.AreEqual(26, result.Values.Count);

            // First Friday should be the Jan 15th, as we skipped the First of the year, and it is Bi-Weekly starting on that First Friday
            Assert.AreEqual(Create(2021, 01, 15).Value, result.Keys.First().Value);
            result.Keys.ToList().ForEach(x => Assert.True(x.Value.DayOfWeek == DayOfWeek.Friday));
            Assert.AreEqual(260, result.Values.Sum(x => x.Value));
        }
    }
}