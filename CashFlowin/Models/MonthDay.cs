using static CashFlowin.Models.Date;

namespace CashFlowin.Models
{
    public class MonthDay
    {
        public Months Month { get; private set; }
        public DaysOfMonth DayOfMonth { get; private set; }
        public MonthDay(Date date)
        {
            Month = (Months)date.Value.Month;
            DayOfMonth = (DaysOfMonth)date.Value.Day;
        }

        public bool IsLeapDay() => Month == Months.February && DayOfMonth == DaysOfMonth.TwentyNineth;
    }
}
