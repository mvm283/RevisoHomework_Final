using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Web.Kendo.Helpers
{
    public static class FilterHelper
    {
        public static void ProcessFilters<T>(GridFilter filter, ref IQueryable<T> queryable)
        {
            var whereClause = string.Empty;
            var filters = filter.Filters;
            var parameters = new List<object>();
            for (int i = 0; i < filters.Count; i++)
            {
                var f = filters[i];

                if (f.Filters == null)
                {
                    if (i == 0)
                        whereClause += BuildWherePredicate<T>(f, i, parameters) + " ";
                    if (i != 0)
                        whereClause += ToLinqOperator(filter.Logic) + BuildWherePredicate<T>(f, i, parameters) + " ";
                    if (i == (filters.Count - 1))
                    {
                        TrimWherePredicate(ref whereClause);
                        var q = queryable.Where(whereClause, parameters.ToArray());
                        queryable = queryable.Where(whereClause, parameters.ToArray());
                    }
                }
                else
                    ProcessFilters(f, ref queryable);
            }
        }

        public static string TrimWherePredicate(ref string whereClause)
        {
            switch (whereClause.Trim().Substring(0, 2).ToLower())
            {
                case "&&":
                    whereClause = whereClause.Trim().Remove(0, 2);
                    break;
                case "||":
                    whereClause = whereClause.Trim().Remove(0, 2);
                    break;
            }

            return whereClause;
        }

        public static string BuildWherePredicate<T>(GridFilter filter, int index, List<object> parameters)
        {
            //var type = typeof(DynamicQueryable).Assembly.GetType("System.Linq.Dynamic.ExpressionParser");

            //FieldInfo field = type.GetField("predefinedTypes", BindingFlags.Static | BindingFlags.NonPublic);

            //Type[] predefinedTypes = (Type[])field.GetValue(null);

            //Array.Resize(ref predefinedTypes, predefinedTypes.Length + 1);
            //predefinedTypes[predefinedTypes.Length - 1] = typeof(DbFunctions);

            //field.SetValue(null, predefinedTypes);
            var entityType = (typeof(T));
            PropertyInfo property;

            if (filter.Field.Contains("."))
                property = GetNestedProp<T>(filter.Field);
            else
                if (filter.Field.EndsWith("En"))
            {
                filter.Field = filter.Field.Substring(0, filter.Field.LastIndexOf("En"));
            }

            var fieldList = filter.Field.Split('.').ToList();
            if (fieldList.Count == 1)
                property = entityType.GetProperty(filter.Field);
            else
            {
                property = entityType.GetProperty(fieldList[0]);
                fieldList.RemoveAt(0);
                while (fieldList.Count > 0)
                {
                    property = (property.PropertyType).GetProperty(fieldList[0]);
                    fieldList.RemoveAt(0);
                }
                //{

                //    fieldList.RemoveAt(0);
                //}

            }

            //PropertyInfo addressProperty = typeof(Customer).GetProperty("Address");
            //ProportyInfo zipCodeProperty = addressProperty.PropertyType.GetProperty("ZipCode");





            var parameterIndex = parameters.Count;

            switch (filter.Operator.ToLower())
            {
                case "eq":
                case "neq":
                case "gte":
                case "gt":
                case "lte":
                case "lt":
                    if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(DateTime.Parse(filter.Value).Date);
                        return string.Format("DbFunctions.TruncateTime(" + filter.Field + ")" + ToLinqOperator(filter.Operator) + "@" + parameterIndex);
                    }
                    if (typeof(DateTime?).IsAssignableFrom(property.PropertyType))
                    {
                        DateTime? dt = DateTime.Parse(filter.Value).Date;
                        parameters.Add(dt);
                        //var ri=Expression.Call(typeof(EntityFunctions), "TruncateTime", null,
                        //        Expression.Convert(Expression.Constant(DateTime.Parse(filter.Value)), typeof(DateTime?)));
                        return string.Format("DbFunctions.TruncateTime(" + filter.Field + ")" + ToLinqOperator(filter.Operator) + "@" + parameterIndex);
                    }
                    if (typeof(int).IsAssignableFrom(property.PropertyType) ||typeof(short).IsAssignableFrom(property.PropertyType)||typeof(long).IsAssignableFrom(property.PropertyType) || typeof(decimal).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(int.Parse(filter.Value));
                        return string.Format(filter.Field + ToLinqOperator(filter.Operator) + "@" + parameterIndex);
                    }
                    if (property.PropertyType.IsEnum)
                    {
                        var t = property.PropertyType;
                        parameters.Add(int.Parse(filter.Value));
                        //parameters.Add((TaskManagement.Domain.Model.RequestStatus)Enum.Parse(typeof(TaskManagement.Domain.Model.RequestStatus), (filter.Value)));
                        return string.Format(filter.Field + " = @" + parameterIndex);
                        return string.Format(filter.Field + ".Equals(" + "@" + parameterIndex + ")");
                    }
                    parameters.Add(filter.Value);
                    return string.Format(filter.Field + ToLinqOperator(filter.Operator) + "@" + parameterIndex);
                case "startswith":
                    parameters.Add(filter.Value);
                    return filter.Field + ".StartsWith(" + "@" + parameterIndex + ")";
                case "endswith":
                    parameters.Add(filter.Value);
                    return filter.Field + ".EndsWith(" + "@" + parameterIndex + ")";
                case "contains":
                    parameters.Add(filter.Value);
                    return filter.Field + ".Contains(" + "@" + parameterIndex + ")";
                case "doesnotcontain":
                    parameters.Add(filter.Value);
                    return "!" + filter.Field + ".Contains(" + "@" + parameterIndex + ")";
                default:
                    throw new ArgumentException("This operator is not yet supported for this Grid", filter.Operator);
            }
        }

        public static string ToLinqOperator(string @operator)
        {
            switch (@operator.ToLower())
            {
                case "eq":
                    return " == ";
                case "neq":
                    return " != ";
                case "gte":
                    return " >= ";
                case "gt":
                    return " > ";
                case "lte":
                    return " <= ";
                case "lt":
                    return " < ";
                case "or":
                    return " || ";
                case "and":
                    return " && ";
                default:
                    return null;
            }
        }

        //public static GridFilter ChangeAliasName<T>(GridFilter filter, string aliasName, string realName)
        //{
        //    if (filter.Field == "StatusName")
        //    {
        //        filter.Field = "Status";
        //        filter.Value =
        //            filter.Value == "جدید" ? filter.Value = ((int)DutyStatus.New).ToString() :
        //            filter.Value == "در حال انجام" ? filter.Value = ((int)DutyStatus.InProgress).ToString() :
        //            filter.Value == "در انتظار تایید" ? filter.Value = ((int)DutyStatus.WaitForAccept).ToString() :
        //            filter.Value == "انجام شد" ? filter.Value = ((int)DutyStatus.Done).ToString() :
        //            filter.Value == "بازگشت داده شده" ? filter.Value = ((int)DutyStatus.Returned).ToString() :
        //            filter.Value == "دیده نشده" ? filter.Value = ((int)DutyStatus.NotSeen).ToString() : filter.Value = ((int)DutyStatus.New).ToString();
        //        filter.Operator = "eq";
        //    }
        //    filter.Filters.ForEach(a =>
        //    {
        //        if (a.Field == "StatusName")
        //        {
        //            a.Field = "Status";
        //            a.Value =
        //                a.Value == "جدید" ? a.Value = ((int)DutyStatus.New).ToString() :
        //                a.Value == "در حال انجام" ? a.Value = ((int)DutyStatus.InProgress).ToString() :
        //                a.Value == "در انتظار تایید" ? a.Value = ((int)DutyStatus.WaitForAccept).ToString() :
        //                a.Value == "انجام شد" ? a.Value = ((int)DutyStatus.Done).ToString() :
        //                a.Value == "بازگشت داده شده" ? a.Value = ((int)DutyStatus.Returned).ToString() :
        //                a.Value == "دیده نشده" ? a.Value = ((int)DutyStatus.NotSeen).ToString() : a.Value = ((int)DutyStatus.New).ToString();
        //            a.Operator = "eq";
        //        }
        //    });
        //    return null;
        //}

        public static PropertyInfo GetNestedProp<T>(String name)
        {
            PropertyInfo info = null;
            var type = (typeof(T));
            foreach (var prop in name.Split('.'))
            {
                info = type.GetProperty(prop);
                type = info.PropertyType;
            }
            return info;
        }
    }
}
