using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework.Web.Kendo.Helpers
{
    public class GridFilter
    {
        public string Operator { get; set; }
        public string Logic { get; set; }
        public string Value { get; set; }
        public string Field { get; set; }
        public List<GridFilter> Filters { get; set; }
    }
    public class GridGroup<T>
    {
        public string field { get; set; }
        public bool hasSubgroups { get; set; }
        public string value { get; set; }
        public List<T> items { get; set; }
        public List<T> aggregates { get; set; }
    }

    public class GridSort
    {
        public string Dir { get; set; }
        public string Field { get; set; }
    }
}