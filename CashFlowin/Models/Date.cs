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

        public Date AddDays(int days) => Create(Value.AddDays(days));

        public static implicit operator DateTime(Date date) => date.Value;

        public Date AddMonths(int months) => Create(Value.AddMonths(months));
        public Date AddYears(int years) => Create(Value.AddYears(years));
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
