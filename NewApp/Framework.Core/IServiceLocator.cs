using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IServiceLocator
    {
        T Resolve<T>();
        object Resolve(Type type);
        List<T> ResolveAll<T>(); 
        void Release(object obj);
    }
}
