namespace ginsu.jqGrid
{
    using System;

    public static class jqExtensions
    {
        public static string GetJqType(this Type type)
        {
            if (typeof (int).Equals(type)) return "int";
            if (typeof (DateTime).Equals(type)) return "date";
            return "string";
        }

    }
}