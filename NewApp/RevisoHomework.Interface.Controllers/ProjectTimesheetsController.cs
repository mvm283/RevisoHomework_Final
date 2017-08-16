using RevisoHomework.Interface.Facade.Contracts.DTO;
using RevisoHomework.Interface.Facade.Contracts.Services;
using Framework.Core;
using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RevisoHomework.Interface.Controllers
{ 
    public class ProjectTimesheetsController : ApiController, IGateway
    {
        private readonly IProjectTimesheetFacade _facade;
        public ProjectTimesheetsController(IProjectTimesheetFacade facade)
        {
            _facade = facade;
        }
        [HttpGet]
        public async Task<IList<ProjectTimesheetDTO>> Get()
        {
            return await _facade.GetAll();
        }
        public async Task<ProjectTimesheetDTO> GetById(long Id)
        {
            return await _facade.GetById(Id); 
        }
        public async Task<IList<ProjectTimesheetDTO>> GetByProjectId(long param)
        {
            return await _facade.GetByProjectId(param); 
        }

        public async Task<GridResult<ProjectTimesheetDTO>> GetAllUsers(int page, int pageSize, string filter, string sort)
        {
            return await _facade.GetAllForGrid(page, pageSize, filter, sort);
        }

        public async Task<ProjectTimesheetDTO> Post(ProjectTimesheetCreateDTO dto)
        {
            return await _facade.Create(dto);
        }
        public async Task<ProjectTimesheetDTO> Put(ProjectTimesheetDTO dto)
        {
            return await _facade.Modify(dto);
        }

        public void Delete(string id)
        {
            _facade.Delete(Convert.ToInt64(id));
        }
    }
}
