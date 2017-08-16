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
    public interface ICustomerFacade : IFacadeService
    {
        Task<CustomerDTO> Create(CustomerCreateDTO dto);

        Task<CustomerDTO> Modify(CustomerDTO dto);

        void Delete(long id);

        Task<IList<CustomerDTO>> GetAll();
        Task<CustomerDTO> GetById(long Id);

        Task<GridResult<CustomerDTO>> GetAllForGrid(int page, int pageSize, string filter, string sort);

    }
}
