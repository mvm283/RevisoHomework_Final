using System;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Framework.Core;
using ServiceHost.Infrastructure;

namespace RevisoHomework.Web
{
    public class ContainerProvider
    {
        public static WindsorContainer GetContainer()
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            Framework.Config.Bootstrapper.WireUp(container);
            RevisoHomework.Config.Bootstrapper.WireUp(container);
            AutoMapperConfiguration.RegisterProfiles(container);
 

            return container;
        }
         

        
    }
}