using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;


namespace Framework.Web.Kendo.Helpers
{
    public static class DynamicQuery<T>
    {
        public static IQueryable<T> DoQuery(System.Linq.IQueryable<T> query, string sortExpression) 
        {
            return query.OrderBy(sortExpression);
        }

    }
   
}
