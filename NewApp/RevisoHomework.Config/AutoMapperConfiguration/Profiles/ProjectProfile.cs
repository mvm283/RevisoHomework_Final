using AutoMapper;
using RevisoHomework.Domain.Model;
using RevisoHomework.Interface.Facade.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Config.AutoMapperConfiguration.Profiles
{ 
    public class ProjectProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProjectModel, ProjectDTO>();
                //.ForMember(dest => dest.CustomerTitle, opt => opt.MapFrom(src => src.Customer.Title));
            Mapper.CreateMap<ProjectDTO, ProjectModel>();
            Mapper.CreateMap<ProjectCreateDTO, ProjectModel>();


        }
    }
}
