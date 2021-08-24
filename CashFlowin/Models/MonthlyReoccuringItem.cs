using static CashFlowin.Models.Date;

namespace CashFlowin.Models
{
    public class MonthlyReoccuringItem : ReoccuringItem<DaysOfMonth>
    {
        public MonthlyReoccuringItem(DaysOfMonth reoccurance, int repeatEvery, Period period, NamedDecimalItem item)
            : base(reoccurance, repeatEvery, period, item, new MonthlyReoccuranceStrategy()) { }

        public override Date Next(Date date)
        {
            if (Reoccurance == date.DayOfMonth)
            {
                return date;
            }
            else if (Reoccurance > (DaysOfMonth)date.Value.Day && IsLastDayOfMonth(date))
            {
                return Date.Create(date.Value.Year, date.Value.Month, (int)LastDayOfMonth(date.Value.Year, date.Month));
            }
            else
            {
                return Next(Date.Create(date.Value.AddDays(1)));
            }
        }
    }
   

    
}
