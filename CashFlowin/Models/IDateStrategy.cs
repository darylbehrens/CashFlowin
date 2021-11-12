using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CashFlowin.Models.Date;

namespace CashFlowin.Models
{

    public interface IValued<T>
    {
        T GetValue();
    }

    public interface INamed
    {
        string GetName();
    }

    public interface IReoccurable
    {
        Date Next(Date date);
        List<DatedNamedDecimalItem> GetBetween(Period period);
    }

    public interface IBounded<T>
    {
        T GetStart();
        T GetEnd();
    }

    public abstract class BoundedItem<T> : IBounded<T>
    {
        public T Start { get; protected set; }
        public T End { get; protected set; }

        public T GetEnd() => End;

        public T GetStart() => Start;
    }

    public class NamedDecimalItem : INamed, IValued<decimal>
    {
        public NamedDecimalItem(string name, decimal value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public string GetName() => Name;

        public decimal GetValue() => Value;

        public override string ToString() => $"{Name} : ${Value}";
    }

    public class DatedNamedDecimalItem
    {
        public DatedNamedDecimalItem(Date date, NamedDecimalItem item)
        {
            Date = date ?? throw new ArgumentNullException(nameof(date));
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public Date Date { get; set; }
        public NamedDecimalItem Item { get; set; }
    }


    public abstract class ReoccuringItem<T> : BoundedItem<Date>, IReoccurable
    {

        public T Reoccurance { get; private set; }
        public int RepeatEvery { get; private set; }
        public NamedDecimalItem Item { get; private set; }
        public ReoccuranceStrategy Strategy { get; private set; }
        public Period GetPeriod() => Period.Create(Start, End);
        public Period UnionPeriod(Period period) => Period.Union(GetPeriod(), period);

        protected ReoccuringItem(T reoccurance, int repeatEvery, Period period, NamedDecimalItem item, ReoccuranceStrategy strategy)
        {
            Reoccurance = reoccurance ?? throw new ArgumentNullException(nameof(reoccurance));
            RepeatEvery = repeatEvery;
            Start = period.Start;
            End = period.End;
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Strategy = strategy;
        }

        public abstract Date Next(Date date);
        public List<DatedNamedDecimalItem> GetBetween(Period period)
        {
            var result = new List<DatedNamedDecimalItem>();

            period = UnionPeriod(period);
            if (period.Start.Value >= period.End.Value) return null; // We need to Setup A Maybe Monad incase of this

            var date = GetFirstInstanceAfter(period.Start);


            while (date.Value <= period.End.Value)
            {
                date = Next(date);
                result.Add(new DatedNamedDecimalItem(date, Item) );
                date = NextInstance(date);
            }
            return result;
        }
        public Date NextInstance(Date date) => Strategy.GetNext(date, RepeatEvery);
        public Date GetFirstInstanceAfter(Date date)
        {
            var startDate = Date.Create(Start.Value);
            while (startDate.Value < date.Value)
            {
                startDate = NextInstance(startDate);
            }
            return startDate;
        }
    }

    public abstract class ReoccuranceStrategy
    {
        public Func<Date,int, Date> GetNext { get; private set; }
        public ReoccuranceStrategy(Func<Date,int, Date> strategy) => GetNext = strategy;
    }

    public sealed class WeeklyReoccuranceStrategy : ReoccuranceStrategy
    {
        public WeeklyReoccuranceStrategy() : base(getNext) { }
        private static Func<Date, int, Date> getNext => (date, repeatEvery) => Create(date.AddDays(repeatEvery * 7));
    }

    public sealed class MonthlyReoccuranceStrategy : ReoccuranceStrategy
    {
        public MonthlyReoccuranceStrategy() : base(getNext) { }
        private static Func<Date, int, Date> getNext => (date, repeatEvery) => Create(date.AddMonths(repeatEvery));
    }
    public sealed class YearlyReoccuranceStrategy : ReoccuranceStrategy
    {
        public YearlyReoccuranceStrategy() : base(getNext) { }
        private static Func<Date, int, Date> getNext => (date, repeatEvery) => Create(date.AddYears(repeatEvery));
    }
}
