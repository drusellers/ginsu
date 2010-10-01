namespace ginsu
{
    using System.Linq.Expressions;

    public class WhereClause
    {
        public string Column { get; set; }
        public object Value { get; set; }
        public ExpressionType Comparator { get; set; }
    }
}