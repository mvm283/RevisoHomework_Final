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
    public interface IProjectFacade : IFacadeService
    {
        Task<ProjectDTO> Create(ProjectCreateDTO dto);

        Task<ProjectDTO> Modify(ProjectDTO dto);

        void Delete(long id);

        Task<IList<ProjectDTO>> GetAll();
        Task<ProjectDTO> GetById(long Id);

        Task<GridResult<ProjectDTO>> GetAllForGrid(int page, int pageSize, string filter, string sort);

    }
}
