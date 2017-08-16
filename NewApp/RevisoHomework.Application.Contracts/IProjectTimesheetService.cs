using RevisoHomework.Domain.Model;
using Framework.Core;
using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Application.Contracts
{ 
    public interface IProjectTimesheetService : IService
    {
        Task<IEnumerable<ProjectTimesheetModel>> GetAll();
        Task<IEnumerable<ProjectTimesheetModel>> GetByProjectId(long Id);
        Task<ProjectTimesheetModel> GetById(long Id);
        Task<GridResult<ProjectTimesheetModel>> GetAllForGrid(int page, int pageSize, string filter, string sort);
        Task<ProjectTimesheetModel> Create(ProjectTimesheetModel request);
        void Delete(long id);
        Task<ProjectTimesheetModel> Modify(ProjectTimesheetModel request);
    }
}
