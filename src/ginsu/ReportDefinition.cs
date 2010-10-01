using System;
using System.Collections.Generic;

namespace ginsu
{
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
            var def= new ReportConfiguration<REPORT>();
            cfg(def);
            return def.BuildDef();
        }
    }
}
