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
    public class CustomerProfile : Profile
    {
        protected override void Configure()
        {  
            Mapper.CreateMap<CustomerModel, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, CustomerModel>();
            Mapper.CreateMap<CustomerCreateDTO, CustomerModel>();


        }
    }
}
