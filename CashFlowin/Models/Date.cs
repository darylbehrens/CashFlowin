using System;

namespace CashFlowin.Models
{
    public class Date
    {
        public DateTime Value { get; private set; }
        // Returning new Date Each time, so Date Class is Immutable

        /// <summary>
        /// Creates a new Date Instance
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static Date Create(DateTime dateTime) => new() { Value = dateTime.Date };

        public static Date Create(int year, int month, int day) => new() { Value = new DateTime(year, month, day).Date };

        public static bool IsLeapYear(int year) => DateTime.IsLeapYear(year);

        public static Date Create(int year, Months month, DaysOfMonth dayOfMonth) => Create(year, (int)month, (int)dayOfMonth);

        /// <summary>
        /// Takes Two Dates and Returns a new Date with the Maximum
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date Max(Date date1, Date date2) => Create(date1.Value > date2.Value ? date1.Value : date2.Value);

        /// <summary>
        /// Takes Two Dates and Returns a new Date with the Minimum
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date Min(Date date1, Date date2) => Create(date1.Value < date2.Value ? date1.Value : date2.Value);

        public DaysOfMonth DayOfMonth
        {
            get => (DaysOfMonth)Value.Day;
        }

        public Months Month
        {
            get => (Months)Value.Month;
        }

        public Date AddDays(int days) => Create(Value.AddDays(days));

        public static implicit operator DateTime(Date date) => date.Value;

        public Date AddMonths(int months) => Create(Value.AddMonths(months));

        public static bool IsLastDayOfMonth(Date date) => date.Value.Day == DateTime.DaysInMonth(date.Value.Year, date.Value.Month);
        public static DaysOfMonth LastDayOfMonth(int year, Months month) => (DaysOfMonth)DateTime.DaysInMonth(year, (int)month);
        public Date AddYears(int years) => Create(Value.AddYears(years));
        public enum Months
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
        public enum DaysOfMonth
        {
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
            ThirtyFirst
        }

    }
    public static class DateTimeExtensions
    {
        public static Date StartOfWeek(this Date dt, DayOfWeek startOfWeek)
        {
            int diff = dt.Value.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff);
        }
    }


    public class Period
    {
        public Date Start { get; private set; }
        public Date End { get; private set; }

        public static Period Create(Date start, Date end) => new() { Start = start, End = end };

        /// <summary>
        /// Returns a new Peirod, where Start date is the Largest of the two, and End Date the Lowest
        /// </summary>
        /// <param name="periodOne"></param>
        /// <param name="periodTwo"></param>
        /// <returns></returns>
        public static Period Union(Period periodOne, Period periodTwo) =>
            new()
            {
                Start = Date.Max(periodOne.Start, periodTwo.Start),
                End = Date.Min(periodOne.End, periodTwo.End)
            };
    }
}
