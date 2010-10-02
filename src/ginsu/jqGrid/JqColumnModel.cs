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
namespace ginsu.jqGrid
{
    using Magnum.Extensions;

    public class JqColumnModel
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public int Width { get; set; }
        public string SortType { get; set; }

        public override string ToString()
        {
            return "{{ name: '{0}', index: '{1}', width: {2}, sorttype: '{3}' }}".FormatWith(Name, Index, Width, SortType);
        }
    }
}