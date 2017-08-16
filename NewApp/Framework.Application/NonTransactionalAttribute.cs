using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NonTransactionalAttribute : Attribute
    {
    }
}
