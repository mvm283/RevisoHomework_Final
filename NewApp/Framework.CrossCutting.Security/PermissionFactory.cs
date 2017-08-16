using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CrossCutting.Security
{
    public static class PermissionFactory
    {
        public static List<Permission> CreateFromEnumType(Type type)
        {
            if (!type.IsEnum) throw  new ArgumentException();
            var values = Enum.GetValues(type);

            var output = new List<Permission>();
            foreach (var value in values)
            {
                var name = Enum.GetName(type, value);
                var code = (int)value;

                var permission = new Permission(code, name);
                output.Add(permission);
            }
            return output;
        }
        public static Permission CreateFromEnumValue(object value)
        {
            var type = value.GetType();
            if (!type.IsEnum) throw new ArgumentException();

            var name = value.ToString();
            var code = (int)value;

            return  new Permission(code,name);
        }
    }
}
