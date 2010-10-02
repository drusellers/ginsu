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
    using System.Collections.Generic;
    using System.Web.Mvc;
    using jqGrid;

    public class ReportController :
        Controller
    {
        public ActionResult Index()
        {
            var o = new JqGridOptions();
            o.Columns = new List<JqColumnModel>()
                { //string, date, int
                new JqColumnModel(){DisplayName = "A",Index="id",Name="id",SortType = "string", Width = 100},
                new JqColumnModel(){DisplayName = "B",Index="invdate",Name="invdate",SortType = "date",Width = 100},
                };
            return View(o);
        }

    }
}