namespace ginsu
{
    using System;

    public interface Column
    {
        int Order { get; set; }
        AggregationStrategy AggregationStrategy { get; set; }
    }

    public class Column<REPORT> :
        Column
    {
        private readonly Func<REPORT, object> _func;

        public Column(Func<REPORT, object> func, int order, AggregationStrategy strat)
        {
            _func = func;
            AggregationStrategy = strat;
            Order = order;
        }

        public object GetData(REPORT obj)
        {
            return _func(obj);
        }

        public int Order { get; set; }

        public AggregationStrategy AggregationStrategy { get; set; }
    }
}