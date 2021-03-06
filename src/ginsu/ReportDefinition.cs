﻿// Copyright 2007-2010 The Apache Software Foundation.
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
    using System.Collections.Generic;

    public class ReportDefinition
    {
        public ReportDefinition()
        {
            Columns = new List<Column>();
        }

        public IList<Column> Columns { get; private set; }
        public Type ReportDataType { get; set; }


        //factory
        public static ReportDefinition New<REPORT>(Action<ReportConfiguration<REPORT>> cfg)
        {
            var def = new ReportConfiguration<REPORT>();
            cfg(def);
            return def.BuildDef();
        }
    }
}