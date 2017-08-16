using System.Collections.Generic;
using System.Linq;
using AutoMapper;
//using AutoMapper.Configuration;
using IConfiguration = AutoMapper.IConfiguration;

namespace RevisoHomework.Web.Infrastructure
{ 
     public static class AutoMapperInitializer
    {
        public static void Initialize(IEnumerable<Profile> profiles)
        {
            Mapper.Initialize(config => AddProfiles(config, profiles));
        }

        private static void AddProfiles(IConfiguration configuration, IEnumerable<Profile> profiles)
        {
            profiles.ToList().ForEach(configuration.AddProfile);
        }
    }
}