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
    public interface IProjectService : IService
    {
        Task<IEnumerable<ProjectModel>> GetAll();
        Task<ProjectModel> GetById(long Id);
        Task<GridResult<ProjectModel>> GetAllForGrid(int page, int pageSize, string filter, string sort);
        Task<ProjectModel> Create(ProjectModel request);
        void Delete(long id);
        Task<ProjectModel> Modify(ProjectModel request);
    }
}
