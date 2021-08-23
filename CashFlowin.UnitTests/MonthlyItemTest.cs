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
        private readonly p TestYearMinusOneDay = p.Create(Create(2021, 1, 2), Create(2021, 12, 31));

        [Test]
        public void TestEveryFifteenth()
        {
            // Arrange
            var testValueItem = new NamedDecimalItem("Test Item", 10);
            var testItem = new MonthlyReoccuringItem(DayOfMonth.Fifteenth, 1, TestYear, testValueItem);

            //Act
            var result = testItem.GetBetween(TestYear);

            // Assert
            // There were 12 Fifteenths in 2021
            Assert.AreEqual(12, result.Values.Count);
            Assert.AreEqual(Create(2021, 1, 15).Value, result.Keys.First().Value);
            result.Keys.ToList().ForEach(x => Assert.AreEqual((DayOfMonth)x.Value.Day,DayOfMonth.Fifteenth));
            Assert.AreEqual(120, result.Values.Sum(x => x.Value));
        }
    }
}