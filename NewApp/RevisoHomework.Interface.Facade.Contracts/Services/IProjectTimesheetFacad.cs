using RevisoHomework.Interface.Facade.Contracts.DTO;
using Framework.Core;
using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Interface.Facade.Contracts.Services
{  
    public interface IProjectTimesheetFacade : IFacadeService
    {
        Task<ProjectTimesheetDTO> Create(ProjectTimesheetCreateDTO dto);

        Task<ProjectTimesheetDTO> Modify(ProjectTimesheetDTO dto);

        void Delete(long id);

        Task<IList<ProjectTimesheetDTO>> GetAll();
        Task<IList<ProjectTimesheetDTO>> GetByProjectId(long id);
        Task<ProjectTimesheetDTO> GetById(long Id);

        Task<GridResult<ProjectTimesheetDTO>> GetAllForGrid(int page, int pageSize, string filter, string sort);

    }
}
