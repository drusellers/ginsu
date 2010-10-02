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
namespace ginsu.web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using jqGrid;

    public class ReportController :
        Controller
    {
        public ActionResult Index()
        {
            var data = new List<DataItem>
                {
                    new DataItem(){Name="Roxy", InvDate = new DateTime(1979,2,26)},
                    new DataItem{Name="Dru", InvDate = new DateTime(2010,10,1)}
                };

            var rtp = ReportDefinition.New<DataItem>(cfg=>
            {
                cfg.Column(d=>d.Name);
                cfg.Column(d=>d.InvDate, e=>e.SetDisplayName("Invoice Date"));
            });

            var o = new JqGridOptions();
            o.Data = data;

            foreach (var column in rtp.Columns)
            {
                o.Columns.Add(new JqColumnModel()
                    {
                        Name = column.Name, 
                        DisplayName = column.DisplayName,
                        Index = column.Name,
                        SortType = column.Type.GetJqType(),
                        Width = 100,
                        Funk = column.Funk
                    });
            }


            return View(o);
        }

    }

    public class DataItem
    {
        public string Name { get; set; }
        public DateTime InvDate { get; set; }
    }
}