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
    public class ProjectFacade : IProjectFacade
    {
        private readonly IProjectService _service;
        private readonly ICustomerService _customerService;
        public ProjectFacade(IProjectService service, ICustomerService customerService)
        {
            _service = service;
            _customerService = customerService;
        }


        public async Task<ProjectDTO> Create(ProjectCreateDTO dto)
        {
            ProjectModel model = new ProjectModel();
            AutoMapper.Mapper.Map(dto, model);

            var customer= await _customerService.GetById(dto.Customer_Id);
            if (customer != null)
            {
                model.Customer = customer;
            } 
            var dep = await _service.Create(model); 
            return AutoMapper.Mapper.Map<ProjectModel, ProjectDTO>(dep);
        }

        public async Task<ProjectDTO> Modify(ProjectDTO dto)
        {
            var model = AutoMapper.Mapper.Map<ProjectDTO, ProjectModel>(dto);

            var customer = await _customerService.GetById(dto.Customer_Id);
            if (customer != null)
            {
                model.Customer = customer;
            }
            var entity = await _service.Modify(model);
            return AutoMapper.Mapper.Map<ProjectModel, ProjectDTO>(entity);
        }

        public void Delete(long id)
        { 
            _service.Delete(id);
        }

        public async Task<IList<ProjectDTO>> GetAll()
        {
            var result = await _service.GetAll();
            var data = result.Select(a => AutoMapper.Mapper.Map<ProjectModel, ProjectDTO>(a)).ToList();
            return data;
        }

        public async Task<GridResult<ProjectDTO>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        {

            var result = await _service.GetAllForGrid(page, pageSize, filter, sort);
            var data = result.Data.Select(AutoMapper.Mapper.Map<ProjectModel, ProjectDTO>).ToList();
            return new GridResult<ProjectDTO>(data, result.Total);
        }

        public async Task<ProjectDTO> GetById(long Id)
        {
            var result = await _service.GetById(Id);
            var data = AutoMapper.Mapper.Map<ProjectModel, ProjectDTO>(result);
            return data;
        }
    }
}
