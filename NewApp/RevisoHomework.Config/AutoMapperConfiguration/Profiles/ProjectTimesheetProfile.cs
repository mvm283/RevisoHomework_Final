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
    public class ProjectTimesheetProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProjectTimesheetModel, ProjectTimesheetDTO>();
                //.ForMember(dest => dest.CustomerTitle, opt => opt.MapFrom(src => src.Customer.Title));
            Mapper.CreateMap<ProjectTimesheetDTO, ProjectTimesheetModel>();
            Mapper.CreateMap<ProjectTimesheetCreateDTO, ProjectTimesheetModel>();


        }
    }
}
