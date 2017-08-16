using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CrossCutting.Security
{
    public class HasPermission  : Attribute
    {
        public Permission Permission { get; private set; }
        public HasPermission(object enumValue)
        {
            Permission = PermissionFactory.CreateFromEnumValue(enumValue);
        }
    }
}
