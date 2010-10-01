using System;

namespace ginsu.specs
{
    using Magnum.TestFramework;

    [Scenario]
    public class ReportConfiguring_Specs
    {
        private ReportDefinition _definition;

        [Given]
        public void A_report_definition()
        {
            _definition = ReportDefinition.New<Report>(cfg =>
            {
                //could be auto mapped
                cfg.Column(r => r.Name);
                cfg.Column(r => r.Amount);
            });
        }

        [Then]
        public void Then_there_should_be_two_columns()
        {
            _definition.Columns.Count.ShouldBeEqualTo(2);

            _definition.Columns[0].Order.ShouldBeEqualTo(0);
            _definition.Columns[0].AggregationStrategy.ShouldBeAnInstanceOf<CountStrategy>();

            _definition.Columns[1].Order.ShouldBeEqualTo(1);
            _definition.Columns[1].AggregationStrategy.ShouldBeAnInstanceOf<SumStrategy>();
        }
    }

    public class Report
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}