
using Accounting.Persistance.EF.Repositories;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RevisoHomework.Application;
using RevisoHomework.Interface.Controllers;
using RevisoHomework.Interface.Facade;
using RevisoHomework.Persistance.EF;
using Framework.Config.LifeStyles;
using Framework.Core;
using Framework.Domain.Model;
using Framework.Persistance.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RevisoHomework.Config
{
   public  class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            const string boundedContextName = "RevisoHomework";
            var unitOfWorkName = boundedContextName + "_UOW";


            container.Register(
                Types.FromThisAssembly()
                    .BasedOn<Profile>()
                    .WithService.Base()
                    .Configure(c => c.Named(c.Implementation.FullName))
                    .LifestyleTransient()); 

            container.Register(Classes.FromAssemblyContaining<CustomerFacade>()
                                    .BasedOn<IFacadeService>()
                                    .WithService.FromInterface()
                                    .LifestyleBoundTo<IGateway>() 
                                    ); 

            container.Register(Classes.FromAssemblyContaining<CustomerService>()
                .BasedOn<IService>()
                .WithService.FromInterface()
                .LifestyleBoundTo<IGateway>()
                .Configure(a => a.DependsOn(Dependency.OnComponent(typeof(IUnitOfWork), unitOfWorkName)))

                );


            container.Register(Classes.FromAssemblyContaining<CustomersController>()
                                    .BasedOn<ApiController>()
                                    .LifestyleScoped<HybridLifeStyleScopeAccessor>());

            container.Register(Classes.FromAssemblyContaining<CustomerRepository>()
                            .BasedOn<IRepository>()
                            .WithService.FromInterface()
                            .LifestyleBoundToNearest<IService>() 
                            );

            container.Register(Component.For<RevisoHomeworkDbContext>().LifestylePerWebRequest().Forward<DbContext>());

            container.Register(Component.For<IUnitOfWork>().UsingFactoryMethod<IUnitOfWork>(a =>
            {
                var context = a.Resolve<RevisoHomeworkDbContext>();
                return new EFUnitOfWork(context);

            }).LifestyleBoundTo<IService>()
                .Named(unitOfWorkName) 

                );
             


        }
    }
}
