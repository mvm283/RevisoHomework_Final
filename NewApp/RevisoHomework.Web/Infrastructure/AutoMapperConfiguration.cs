using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RevisoHomework.Web.Infrastructure;

namespace ServiceHost.Infrastructure
{ 
        public static class AutoMapperConfiguration
        {
            public static void RegisterProfiles(IWindsorContainer windsorContainer)
            {
                var profiles = windsorContainer.ResolveAll<Profile>();

                if (profiles.Length > 0)
                {
                    AutoMapperInitializer.Initialize(profiles);
                }
                //Mapper.AssertConfigurationIsValid();
            }
        }
    }
