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
    public class ProjectsController : ApiController, IGateway
    {
        private readonly IProjectFacade _facade;
        public ProjectsController(IProjectFacade facade)
        {
            _facade = facade;
        }
        [HttpGet]
        public async Task<IList<ProjectDTO>> Get()
        {
            return await _facade.GetAll();
        }
        public async Task<ProjectDTO> GetById(long Id)
        {
            return await _facade.GetById(Id);
        }

        public async Task<GridResult<ProjectDTO>> GetAllUsers(int page, int pageSize, string filter, string sort)
        {
            return await _facade.GetAllForGrid(page, pageSize, filter, sort);
        }

        public async Task<ProjectDTO> Post(ProjectCreateDTO dto)
        {
            return await _facade.Create(dto);
        }
        public async Task<ProjectDTO> Put(ProjectDTO dto)
        {
            return await _facade.Modify(dto);
        }

        public void Delete(string id)
        {
            _facade.Delete(Convert.ToInt64(id));
        }
    }
}
