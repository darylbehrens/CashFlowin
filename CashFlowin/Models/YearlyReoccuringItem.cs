namespace CashFlowin.Models
{
    public class YearlyReoccuringItem : ReoccuringItem<MonthDay>
    {
        public YearlyReoccuringItem(MonthDay reoccurance, int repeatEvery, Period period, NamedDecimalItem item)
            : base(reoccurance, repeatEvery, period, item, new YearlyReoccuranceStrategy()) { }

        public override Date Next(Date date)
        {
            var thisDate = (Date.Create(date.Value.Year, (int)Reoccurance.Month, (int)Reoccurance.DayOfMonth));
            if (date <= thisDate.Value)
            {
                return thisDate;
            }
            else 
            {
                return Date.Create(date.Value.Year + 1, (int)Reoccurance.Month, (int)Reoccurance.DayOfMonth);
            }
        }
    }
}
