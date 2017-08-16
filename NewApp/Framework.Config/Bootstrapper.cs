using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Config.LifeStyles;
using Framework.Core;

using Framework.Domain.Model;

namespace Framework.Config
{
    public static class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
             
            container.Register(Component.For<DbConnection>().UsingFactoryMethod<DbConnection>(a =>
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }).OnDestroy(a => a.Close()).LifestyleScoped<HybridLifeStyleScopeAccessor>());


            ServiceLocator.Current = new WindsorServiceLocator(container); 
          
        }
    }
}
