using NUnit.Framework;
using p = CashFlowin.Models.Period;
using static CashFlowin.Models.Date;
using CashFlowin.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CashFlowin.UnitTests
{
    class FunctionalTests
    {
        private readonly p TestPeriod = p.Create(Create(2021, 8, 27), Create(2021, 9, 17));
        private readonly p ItemPeriod = p.Create(Create(2021, 8, 27), Create(2021, 9, 17));


        [Test]
        public void TestNextFourthOfJulyAtStartOfYear()
        {
            // Arrange
            var Job = new BiweeklyReoccuringItem(System.DayOfWeek.Friday, ItemPeriod, new NamedDecimalItem("Job", 3019));
            var House = new MonthlyReoccuringItem(DaysOfMonth.First, 1, ItemPeriod, new NamedDecimalItem("Mortgage", -3000));
            var Groceries = new WeeklyReoccuringItem(System.DayOfWeek.Friday, 1, ItemPeriod, new NamedDecimalItem("Groceries", -50));

            var Items = new List<IReoccurable>();
            Items.Add(Job);
            Items.Add(House);
            Items.Add(Groceries);

            var results = new List<DatedNamedDecimalItem>();
            foreach (var item in Items)
            {
                results.Concat(item.GetBetween(TestPeriod));
            }

            foreach (var result in results)
            {
                Console.WriteLine();
            }

            // Act
        }
    }
}