using System;
using System.Collections.Generic;

namespace CashFlowin.Models
{

    public class WeeklyReoccuringItem : ReoccuringItem<DayOfWeek>
    {
        public WeeklyReoccuringItem(DayOfWeek reoccurance, int repeatEvery, Period period, NamedDecimalItem item)
            : base(reoccurance, repeatEvery, period, item, new WeeklyReoccuranceStrategy()) { }

        public override Date Next(Date date)
        {
            if (Reoccurance == date.Value.DayOfWeek)
            {
                return date;
            }
            else
            {
                return Next(Date.Create(date.Value.AddDays(1)));
            }
        }
    }
}
