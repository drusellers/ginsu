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
namespace ginsu.jqGrid
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Magnum.Extensions;

    public class JqGridOptions
    {
        public JqGridOptions()
        {
            Columns = new List<JqColumnModel>();
        }

        public IList<JqColumnModel> Columns { get; set; }

        public string GetColumnNames()
        {
            return Columns.Select(c => c.DisplayName).Aggregate((l, r) => "'{0}', '{1}'".FormatWith(l, r));
        }

        public IEnumerable<object> Data { get; set; }

        public string GetData()
        {
            var sb = new StringBuilder();

            sb.Append("[");

            foreach (var row in Data)
            {
                sb.Append("{");
                foreach (var c in Columns)
                {
                    sb.AppendFormat("{0} : '{1}',", c.Name.ToLower(), c.GetValue(row));
                }
                sb.Append("},");
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}