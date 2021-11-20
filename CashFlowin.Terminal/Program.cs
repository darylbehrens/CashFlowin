using System;
using System.Linq;
using CashFlowin.Models;
using p = CashFlowin.Models.Period;
using static CashFlowin.Models.Date;
using System.Collections.Generic;
using CashFlowin.Web.Models;
using System.Globalization;

namespace CashFlowin.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //var date = Date.Create(DateTime.Today);
            //do
            //{
            //    var r = date.StartOfWeek(DayOfWeek.Friday);
            //    Console.WriteLine(r.Value);
            //    date = date.AddDays(1);
            //} while (date.Value <= Date.Create(DateTime.Today.AddDays(20)));


            //    Console.ReadLine();

            p TestPeriod = p.Create(Create(2021, 11, 12), Create(2030, 12,31));
            p ItemPeriod = p.Create(Create(2021, 11, 10), Create(2051, 9, 17));
            p MortgagePeriod = p.Create(Create(2022, 03, 1), Create(2051, 11, 1));
            p WorkIncomePeriodOne = p.Create(Create(2021, 11, 19), Create(2023, 05, 31));
            p WorkIncomePeriodTwo = p.Create(Create(2023, 06, 01), Create(2026, 06,26));
            p WorkIncomePeriodThree = p.Create(Create(2026, 06, 27), Create(2059, 12, 31));

            //var period = Period.Create(Date.Create(2021, 8, 20), Date.Create(2021, 09, 20));


            //var item1 = new NamedDecimalItem("Credit Card", 10);
            //var creditCard = new WeeklyReoccuringItem(DayOfWeek.Friday,2, period, item1);
            //var date = Date.Create(2020,08,01);
            //Console.WriteLine(creditCard.Next(date).Value);
            //var result = creditCard.GetBetween(Period.Create(date, date.AddDays(50)));
            //foreach (var instance in result)
            //{
            //    Console.WriteLine(instance.Key.Value.ToShortDateString(), instance.Value.ToString());
            //}
            //var total = result.Select(x => x.Value).Sum(x => x.Value);
            //Console.WriteLine(total);
            var Job = new BiweeklyReoccuringItem(System.DayOfWeek.Friday, WorkIncomePeriodOne, new NamedDecimalItem("Job", 2950));
            var Job2 = new BiweeklyReoccuringItem(System.DayOfWeek.Friday, WorkIncomePeriodTwo, new NamedDecimalItem("Job", 3019));
            var Job3 = new BiweeklyReoccuringItem(System.DayOfWeek.Friday, WorkIncomePeriodThree, new NamedDecimalItem("Job", 4500));
            var Bonus = new YearlyReoccuringItem(new MonthDay(Date.Create(2021, 12, 25)), 1, ItemPeriod, new NamedDecimalItem("Bonus", 6000));
            var House = new MonthlyReoccuringItem(DaysOfMonth.First, 1, MortgagePeriod, new NamedDecimalItem("Mortgage", -2443));
            var Groceries = new WeeklyReoccuringItem(System.DayOfWeek.Thursday, 1, ItemPeriod, new NamedDecimalItem("Groceries", -160));
            var Electric = new MonthlyReoccuringItem(DaysOfMonth.First, 1, ItemPeriod, new NamedDecimalItem("Electric", -120));
            var Water = new MonthlyReoccuringItem(DaysOfMonth.TwentyFourth, 1, ItemPeriod, new NamedDecimalItem("Water", -100));
            var Garbage = new MonthlyReoccuringItem(DaysOfMonth.TwentyFourth, 1, ItemPeriod, new NamedDecimalItem("Garbage", -25));
            var Gas = new MonthlyReoccuringItem(DaysOfMonth.TwentyFourth, 1, ItemPeriod, new NamedDecimalItem("Gas", -50));
            var CellPhone = new MonthlyReoccuringItem(DaysOfMonth.Eleventh, 1, ItemPeriod, new NamedDecimalItem("Cell Phone", -325));
            var Experian = new MonthlyReoccuringItem(DaysOfMonth.TwentySecond, 1, ItemPeriod, new NamedDecimalItem("Experian", -25));
            var Comcast = new MonthlyReoccuringItem(DaysOfMonth.TwentyFourth, 1, ItemPeriod, new NamedDecimalItem("Comcast", -90));
            var Spotify = new MonthlyReoccuringItem(DaysOfMonth.Twelefth, 1, ItemPeriod, new NamedDecimalItem("Spotify", -20));
            var CarInsurance = new MonthlyReoccuringItem(DaysOfMonth.TwentyFourth, 1, ItemPeriod, new NamedDecimalItem("Car Insurance", -185));
            var Fuel = new WeeklyReoccuringItem(System.DayOfWeek.Thursday, 1, ItemPeriod, new NamedDecimalItem("Fuel", -60));
            var KidsAllowance = new WeeklyReoccuringItem(System.DayOfWeek.Friday, 1, ItemPeriod, new NamedDecimalItem("Kids Allowance", -40));
            var DarylsAllowance = new WeeklyReoccuringItem(System.DayOfWeek.Thursday, 1, ItemPeriod, new NamedDecimalItem("Daryls Allowance", -100));
            var BedSynchrony = new MonthlyReoccuringItem(DaysOfMonth.Nineth, 1, ItemPeriod, new NamedDecimalItem("Bed - Synchrony", -128));
            var CarMax = new MonthlyReoccuringItem(DaysOfMonth.Seventh, 1, ItemPeriod, new NamedDecimalItem("CarMax", -338));
            var PianoSynchrony = new MonthlyReoccuringItem(DaysOfMonth.Fourteenth, 1, ItemPeriod, new NamedDecimalItem("Piano - Synchrony", -224));
            var SweetWater = new MonthlyReoccuringItem(DaysOfMonth.Eighteenth, 1, ItemPeriod, new NamedDecimalItem("Sweetwater", -107));
            var GuitarCenter = new MonthlyReoccuringItem(DaysOfMonth.Eighteenth, 1, ItemPeriod, new NamedDecimalItem("Guitar Center", -147));
            var Dell = new MonthlyReoccuringItem(DaysOfMonth.Eighteenth, 1, ItemPeriod, new NamedDecimalItem("Dell", -200));
            var Beacock = new MonthlyReoccuringItem(DaysOfMonth.Eighteenth, 1, ItemPeriod, new NamedDecimalItem("Beacock", -132));
            var Reverb = new MonthlyReoccuringItem(DaysOfMonth.Eighteenth, 1, ItemPeriod, new NamedDecimalItem("Reverb", -60));
            var BestBuy = new MonthlyReoccuringItem(DaysOfMonth.Twelefth, 1, ItemPeriod, new NamedDecimalItem("Best Buy Card", -106));
            var CitiCard = new MonthlyReoccuringItem(DaysOfMonth.Seventh, 1, ItemPeriod, new NamedDecimalItem("Citi Credit Card", -35));
            var SquareSpace = new MonthlyReoccuringItem(DaysOfMonth.Third, 1, ItemPeriod, new NamedDecimalItem("Squarespace", -29));
            var Therapy = new WeeklyReoccuringItem(System.DayOfWeek.Tuesday, 1, ItemPeriod, new NamedDecimalItem("Jolene", -20));
            //var RainyDay = new WeeklyReoccuringItem(System.DayOfWeek.Friday, 1, ItemPeriod, new NamedDecimalItem("Rainy Day", -200));



            var Items = new List<IReoccurable>();
            Items.Add(Job); Items.Add(Job2); Items.Add(Job3);
            Items.Add(House);
            Items.Add(Groceries);
            Items.Add(Electric);
            Items.Add(Water);
            Items.Add(Garbage);
            Items.Add(Gas);
            Items.Add(CellPhone);
            Items.Add(Experian);
            Items.Add(Comcast);
            Items.Add(Spotify);
            Items.Add(CarInsurance);
            Items.Add(Fuel);
            Items.Add(KidsAllowance);
            Items.Add(DarylsAllowance);
            Items.Add(BedSynchrony);
            Items.Add(CarMax);
            Items.Add(PianoSynchrony);
            Items.Add(SweetWater);
            Items.Add(BestBuy);
            Items.Add(CitiCard);
            Items.Add(SquareSpace);
            Items.Add(Therapy);
            Items.Add(Beacock);
            Items.Add(Dell);
            Items.Add(GuitarCenter);
            Items.Add(Reverb);
            //Items.Add(Bonus);
            ////Items.Add(RainyDay);

            var results = new List<DatedNamedDecimalItem>();
            foreach (var item in Items)
            { 
                foreach (var result in item.GetBetween(TestPeriod))
                {
                results.Add(result);
                  
                }
            }

            //foreach (var result in results.OrderBy(x => x.Date.Value))
            //{
            //    Console.WriteLine(result.Date.Value.ToShortDateString());
            //        Console.WriteLine($"    {result.ToString()}");
                

            //}

            ReportGenerator.SaveReport(new System.IO.FileInfo($@"C:\temp\{DateTime.Now.ToString("MMddyyhhmmss")}.xlsx"), ReportType.Yearly, Date.Create(DateTime.Today), results,8000);
            var total = results.Sum(x => x.Item.Value);
            Console.WriteLine(total);
        }
    }
}


