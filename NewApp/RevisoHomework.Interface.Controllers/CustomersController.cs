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
    public class CustomersController : ApiController, IGateway
    {
        private readonly ICustomerFacade _facade;
        public CustomersController(ICustomerFacade facade)
        {
            _facade = facade;
        }
        [HttpGet]
        public async Task<IList<CustomerDTO>> Get()
        {
            return await _facade.GetAll();
        }
        public async Task<CustomerDTO> GetById(long Id)
        {
            return await _facade.GetById(Id);

            //var Item = await _facade.GetById(Id);
            //if (Item == null)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //return Item;
        }

        public async Task<GridResult<CustomerDTO>> GetAllUsers(int page, int pageSize, string filter, string sort)
        {
            return await _facade.GetAllForGrid(page, pageSize, filter, sort);
        }

        public async Task<CustomerDTO> Post(CustomerCreateDTO dto)
        {
            return await _facade.Create(dto);
        }
        public async Task<CustomerDTO> Put(CustomerDTO dto)
        {
            return await _facade.Modify(dto);
        }

        public void Delete(string id)
        {
            _facade.Delete(Convert.ToInt64(id));
        }
    }
}
