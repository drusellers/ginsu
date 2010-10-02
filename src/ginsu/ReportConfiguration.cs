// Copyright 2007-2010 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace ginsu
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Magnum.Extensions;

    public interface ReportConfiguration
    {
    }

    public class ReportConfiguration<REPORT>
    {
        readonly ReportDefinition _definition;

        public ReportConfiguration()
        {
            _definition = new ReportDefinition();
        }

        public ReportDefinition BuildDef()
        {
            return _definition;
        }

        public void Column(Expression<Func<REPORT, object>> func, Action<ColumnOptions> columnOptions = null)
        {
            string name = func.MemberName();
            Type t = func.GetMemberPropertyInfo().PropertyType;
            AggregationStrategy strat = new CountStrategy();

            var sumTypes = new[]
                {
                    typeof (decimal),
                    typeof (int),
                    typeof (float)
                };
            if (sumTypes.Any(tt => tt.Equals(t)))
                strat = new SumStrategy();


            var column = new Column<REPORT>(name, t, func.Compile(), _definition.Columns.Count, strat);
            if (columnOptions != null) columnOptions(column);
            _definition.Columns.Add(column);
        }
    }

    public interface ColumnOptions
    {
        void SetDisplayName(string displayName);
    }
}