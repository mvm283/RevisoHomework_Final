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
    public class ProjectTimesheetService : IProjectTimesheetService
    { 
        private readonly IProjectTimesheetRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectTimesheetService(IProjectTimesheetRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectTimesheetModel>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<ProjectTimesheetModel> GetById(long Id)
        {
            return await _repository.Get(Id);
        }
        public async Task<IEnumerable<ProjectTimesheetModel>> GetByProjectId(long Id)
        {  
            return await _repository.Get(a => a.Project.Id == Id);
        }
        public async Task<GridResult<ProjectTimesheetModel>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        { 
                return await _repository.GetAllForGrid(page, pageSize, filter, sort); 
        }

        public async Task<ProjectTimesheetModel> Create(ProjectTimesheetModel model)
        {
            _unitOfWork.Begin();
            _repository.Create(model);
            _unitOfWork.Commit();
            return model;

        }

        public async Task<ProjectTimesheetModel> Modify(ProjectTimesheetModel model)
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
