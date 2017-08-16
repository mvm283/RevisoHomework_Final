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
    public class ProjectTimesheetFacade : IProjectTimesheetFacade
    {
        private readonly IProjectTimesheetService _service;
        private readonly IProjectService _ProjectService;
        public ProjectTimesheetFacade(IProjectTimesheetService service, IProjectService ProjectService)
        {
            _service = service;
            _ProjectService = ProjectService;
        }


        public async Task<ProjectTimesheetDTO> Create(ProjectTimesheetCreateDTO dto)
        {
            ProjectTimesheetModel model = new ProjectTimesheetModel();
            AutoMapper.Mapper.Map(dto, model);

            var Project= await _ProjectService.GetById(dto.Project_Id);
            if (Project != null)
            {
                model.Project = Project;
            } 
            var dep = await _service.Create(model); 
            return AutoMapper.Mapper.Map<ProjectTimesheetModel, ProjectTimesheetDTO>(dep);
        }

        public async Task<ProjectTimesheetDTO> Modify(ProjectTimesheetDTO dto)
        {
            var model = AutoMapper.Mapper.Map<ProjectTimesheetDTO, ProjectTimesheetModel>(dto);

            var Project = await _ProjectService.GetById(dto.Project_Id);
            if (Project != null)
            {
                model.Project = Project;
            }
            var entity = await _service.Modify(model);
            return AutoMapper.Mapper.Map<ProjectTimesheetModel, ProjectTimesheetDTO>(entity);
        }

        public void Delete(long id)
        { 
            _service.Delete(id);
        }

        public async Task<IList<ProjectTimesheetDTO>> GetAll()
        {
            var result = await _service.GetAll();
            var data = result.Select(a => AutoMapper.Mapper.Map<ProjectTimesheetModel, ProjectTimesheetDTO>(a)).ToList();
            return data;
        }

        public async Task<GridResult<ProjectTimesheetDTO>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        {

            var result = await _service.GetAllForGrid(page, pageSize, filter, sort);
            var data = result.Data.Select(AutoMapper.Mapper.Map<ProjectTimesheetModel, ProjectTimesheetDTO>).ToList();
            return new GridResult<ProjectTimesheetDTO>(data, result.Total);
        }

        public async Task<ProjectTimesheetDTO> GetById(long Id)
        {
            var result = await _service.GetById(Id);
            var data = AutoMapper.Mapper.Map<ProjectTimesheetModel, ProjectTimesheetDTO>(result);
            return data;
        }
        public async Task<IList<ProjectTimesheetDTO>> GetByProjectId(long Id)
        {
            var result = await _service.GetByProjectId(Id); 
            var data = result.Select(a => AutoMapper.Mapper.Map<ProjectTimesheetModel, ProjectTimesheetDTO>(a)).ToList();
            return data; 
        }
    }
}
