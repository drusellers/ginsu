namespace ginsu
{
    using System;
    using System.Linq.Expressions;

    public interface ReportConfiguration
    {
    }

    public class ReportConfiguration<REPORT>
    {
        private readonly ReportDefinition _definition;

        public ReportConfiguration()
        {
            _definition = new ReportDefinition();
        }

        public ReportDefinition BuildDef()
        {
            return _definition;
        }

        public void Column(Expression<Func<REPORT, object>> func)
        {
            var t = func.Body.Type;
            
            AggregationStrategy strat = new CountStrategy();

            if (typeof(int).Equals(t))
                strat = new SumStrategy();

            _definition.Columns.Add(new Column<REPORT>(func.Compile(), _definition.Columns.Count, strat));
        }
    }
}