using System;

namespace CashFlowin.Models
{
    // Syntatic Sugar for BiWeekly :)
    public sealed class BiweeklyReoccuringItem : WeeklyReoccuringItem
    {
        public BiweeklyReoccuringItem(DayOfWeek reoccurance, Period period, NamedDecimalItem item)
            : base(reoccurance, 2, period, item)
        {
        }
    }
}
