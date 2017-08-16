using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Framework.Config.LifeStyles;
using ServiceHost.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Web.Tests
{
    public class GetContainerProvicder
    {
        public static WindsorContainer GetContainer()
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

             var connectionString = "Data Source=localhost\\sql2008;Initial Catalog=BehineSazanCRM;Integrated Security=True;Connection Timeout=1080;";

            container.Register(Component.For<DbConnection>().UsingFactoryMethod<DbConnection>(a =>
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }).OnDestroy(a => a.Close()).LifestyleScoped<HybridLifeStyleScopeAccessor>());


            RevisoHomework.Config.Bootstrapper.WireUp(container);
            AutoMapperConfiguration.RegisterProfiles(container);


            return container;
        }



    }
}
