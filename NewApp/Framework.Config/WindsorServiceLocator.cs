using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Framework.Core;

namespace Framework.Config
{
    public class WindsorServiceLocator : IServiceLocator
    {
        private readonly IWindsorContainer _container;
        public WindsorServiceLocator(IWindsorContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public List<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>().ToList();
        }

        public void Release(object obj)
        {
            _container.Release(obj);
        }
    }
}
