using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework.Web.Kendo.Helpers
{
    public class GridResult<T>
    {
        public List<T> Data { get; set; }
        
        public long Total { get; set; }
        public List<GridGroup<T>> Group { get; set; }

        public GridResult(List<T> data, long total)
        {
            Data = data;
            Total = total;
        }
        public GridResult(List<T> data, long total, List<GridGroup<T>> group)
        {
            Data = data;
            Total = total;
            Group = group;
        }
    }
}