using System;
using System.Linq;
using CashFlowin.Models;

namespace CashFlowin.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var period = Period.Create(Date.Create(2021, 8, 20), Date.Create(2021, 09, 20));


            var item1 = new NamedDecimalItem("Credit Card", 10);
            var creditCard = new WeeklyReoccuringItem(DayOfWeek.Friday,2, period, item1);
            var date = Date.Create(2020,08,01);
            Console.WriteLine(creditCard.Next(date).Value);
            var result = creditCard.GetBetween(Period.Create(date, date.AddDays(50)));
            foreach (var instance in result)
            {
                Console.WriteLine(instance.Key.Value.ToShortDateString(), instance.Value.ToString());
            }
            var total = result.Select(x => x.Value).Sum(x => x.Value);
            Console.WriteLine(total);
            
        }
    }
}
