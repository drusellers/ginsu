using System;

namespace ginsu.specs
{
    using Magnum.TestFramework;
    using NUnit.Framework;

    [TestFixture]
    public class ReportConfiguring_Specs
    {
        private ReportDefinition _definition;

        [Given]
        public void A_report_definition()
        {
            _definition = ReportDefinition.New<Report>(cfg =>
            {
                //could be auto mapped
                cfg.Column(r => r.Name, o=>o.SetDisplayName("Full Name"));
                cfg.Column(r => r.Amount);
            });
        }

        [Then]
        public void Then_there_should_be_two_columns()
        {
            _definition.Columns.Count.ShouldBeEqualTo(2);
        }

        [Then]
        public void Order_should_be_perserved()
        {
            _definition.Columns[0].Order.ShouldBeEqualTo(0);
            _definition.Columns[1].Order.ShouldBeEqualTo(1);
        }

        [Then]
        public void Then_column_amount_should_be_named_amount()
        {
            _definition.Columns[1].DisplayName.ShouldBeEqualTo("Amount"); 
        }

        [Then]
        public void Then_column_name_should_be_named_Full_Name()
        {
            _definition.Columns[0].DisplayName.ShouldBeEqualTo("Full Name");
        }

        [Then]
        public void Then_the_string_column_should_have_a_count_strategy()
        {
            _definition.Columns[0].AggregationStrategy.ShouldBeAnInstanceOf<CountStrategy>();
        }

        [Then]
        public void Then_the_int_column_should_have_a_sum_strategy()
        {
            _definition.Columns[1].AggregationStrategy.ShouldBeAnInstanceOf<SumStrategy>();
        }
    }

    public class Report
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}