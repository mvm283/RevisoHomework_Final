using RevisoHomework.Application.Contracts;
using RevisoHomework.Domain.Model;
using RevisoHomework.Interface.Facade.Contracts.DTO;
using RevisoHomework.Interface.Facade.Contracts.Services;

using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Interface.Facade
{ 
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICustomerService _service;
        public CustomerFacade(ICustomerService service)
        {
            _service = service;
        }


        public async Task<CustomerDTO> Create(CustomerCreateDTO dto)
        {
            CustomerModel model = new CustomerModel();
            AutoMapper.Mapper.Map(dto, model);
            var dep = await _service.Create(model);

            var ret = AutoMapper.Mapper.Map<CustomerModel, CustomerDTO>(dep);
            return AutoMapper.Mapper.Map<CustomerModel, CustomerDTO>(dep);
        }

        public async Task<CustomerDTO> Modify(CustomerDTO dto)
        {
            var a = AutoMapper.Mapper.Map<CustomerDTO, CustomerModel>(dto);
            var entity = await _service.Modify(a);
            return AutoMapper.Mapper.Map<CustomerModel, CustomerDTO>(entity);
        }

        public void Delete(long id)
        { 
            _service.Delete(id);
        }

        public async Task<IList<CustomerDTO>> GetAll()
        {
            var result = await _service.GetAll();
            var data = result.Select(a => AutoMapper.Mapper.Map<CustomerModel, CustomerDTO>(a)).ToList();
            return data;
        }

        public async Task<GridResult<CustomerDTO>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        {

            var result = await _service.GetAllForGrid(page, pageSize, filter, sort);
            var data = result.Data.Select(AutoMapper.Mapper.Map<CustomerModel, CustomerDTO>).ToList();
            return new GridResult<CustomerDTO>(data, result.Total);
        }

        public async Task<CustomerDTO> GetById(long Id)
        {
            var result = await _service.GetById(Id);
            var data = AutoMapper.Mapper.Map<CustomerModel, CustomerDTO>(result);
            return data;
        }
    }
}
