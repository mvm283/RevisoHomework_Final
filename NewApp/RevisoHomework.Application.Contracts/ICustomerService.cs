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
    public interface ICustomerService : IService
    {
        Task<IEnumerable<CustomerModel>> GetAll();
        Task<CustomerModel> GetById(long Id);
        Task<GridResult<CustomerModel>> GetAllForGrid(int page, int pageSize, string filter, string sort);
        Task<CustomerModel> Create(CustomerModel request);
        void Delete(long id);
        Task<CustomerModel> Modify(CustomerModel request);
    }
}
