namespace ginsu
{
    using System.Collections.Generic;

    public class QueryOptions
    {
        public QueryOptions()
        {
            ColumnsToShow = new HashSet<string>();
            GroupBy = new HashSet<string>();
            SortBy = new HashSet<string>();
        }

        public ICollection<string> ColumnsToShow { get; set; }
        public ICollection<string> GroupBy { get; set; }
        public ICollection<string> SortBy { get; set; }
        public ICollection<WhereClause> Filters { get; set; }
    }
}