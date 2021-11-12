using NUnit.Framework;
using System;
using p = CashFlowin.Models.Period;
using static CashFlowin.Models.Date;
using CashFlowin.Models;
using System.Linq;

namespace CashFlowin.UnitTests
{
    class MonthlyItemTest
    {
        private readonly p TestYear = p.Create(Create(2021, 1, 1), Create(2021, 12, 31));

        [Test]
        public void TestEveryFifteenth()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new MonthlyReoccuringItem(DaysOfMonth.Fifteenth, 1, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYear);

            // Assert
            // There were 12 Fifteenths in 2021
            Assert.AreEqual(12, result.Count);
            Assert.AreEqual(Create(2021, 1, 15).Value, result.First().Date);
            result.ForEach(x => Assert.AreEqual((DaysOfMonth)x.Date.DayOfMonth,DaysOfMonth.Fifteenth));
            Assert.AreEqual(120, result.Sum(x => x.Item.Value));
        }

        [Test]
        public void TestLastDayStartingOnJanuary31()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new MonthlyReoccuringItem(DaysOfMonth.ThirtyFirst, 1, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYear);

            // Assert
            // There were 12 Last Day Of Month in 2021
            Assert.AreEqual(12, result.Count);

            // Test that if a month has less days it will still go to last day
            Assert.AreEqual(Create(2021, 2, 28).Value, result.Skip(1).First().Date);
            Assert.AreEqual(120, result.Sum(x => x.Item.Value));
        }
    }
}