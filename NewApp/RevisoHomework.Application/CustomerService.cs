using RevisoHomework.Application.Contracts;
using RevisoHomework.Domain.Contracts;
using RevisoHomework.Domain.Model;
using Framework.Core;
using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Application
{
    public class CustomerService :ICustomerService
    { 
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<CustomerModel> GetById(long Id)
        {
            return await _repository.Get(Id);
        }
        public async Task<GridResult<CustomerModel>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        {
            return await _repository.GetAllForGrid(page, pageSize, filter, sort);
        }

        public async Task<CustomerModel> Create(CustomerModel model)
        {
            _unitOfWork.Begin();
            _repository.Create(model);
            _unitOfWork.Commit();
            return model;

        }

        public async Task<CustomerModel> Modify(CustomerModel model)
        {
            _unitOfWork.Begin();
            _repository.Update(model);
            _unitOfWork.Commit();
            return model;
        }

        public async void Delete(long id)
        {
            _unitOfWork.Begin();
            _repository.Delete(a => a.Id == id);
            _unitOfWork.Commit();
        }
    }
}
