using System;
using System.Collections.Generic;

namespace CashFlowin.Models
{
    public class MonthlyReoccuringItem : ReoccuringItem<DayOfMonth>
    {
        public MonthlyReoccuringItem(DayOfMonth reoccurance, int repeatEvery, Period period, NamedDecimalItem item)
            : base(reoccurance, repeatEvery, period, item, new MonthlyReoccuranceStrategy()) { }

        public override Date Next(Date date)
        {
            if (Reoccurance == (DayOfMonth)date.Value.Day)
            {
                return date;
            }
            else
            {
                return Next(Date.Create(date.Value.AddDays(1)));
            }
        }
    }

    public enum DayOfMonth
    {
        Last = 0,
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eighth,
        Nineth,
        Tenth,
        Eleventh,
        Twelefth,
        Thirteenth,
        Fourteenth,
        Fifteenth,
        Sixteenth,
        Seventeenth,
        Eighteenth,
        Nineteenth,
        Twentyieth,
        TwentyFirst,
        TwentySecond,
        TwentyThird,
        TwentyFourth,
        TwentyFifth,
        TwentySixth,
        TwentySeventh,
        TwentyEighth,
        TwentyNineth,
        Thrityeith,
        ThirtyFirst,




    }
}
