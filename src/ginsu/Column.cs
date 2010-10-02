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

    public interface Column
    {
        int Order { get; set; }
        AggregationStrategy AggregationStrategy { get; set; }
        string Name { get; set; }
    }

    public class Column<REPORT> :
        Column, ColumnOptions
    {
        readonly Func<REPORT, object> _func;

        public Column(string name, Func<REPORT, object> func, int order, AggregationStrategy strat)
        {
            _func = func;
            Name = name;
            AggregationStrategy = strat;
            Order = order;
        }

        public object GetData(REPORT obj)
        {
            return _func(obj);
        }

        public string Name { get; set; }

        public int Order { get; set; }

        public AggregationStrategy AggregationStrategy { get; set; }

        public void DisplayName(string displayName)
        {
            Name = displayName;
        }
    }
}