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
    public class ProjectService : IProjectService
    { 
        private readonly IProjectRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectModel>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<ProjectModel> GetById(long Id)
        {
            return await _repository.Get(Id);
        }
        public async Task<GridResult<ProjectModel>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        { 
                return await _repository.GetAllForGrid(page, pageSize, filter, sort); 
        }

        public async Task<ProjectModel> Create(ProjectModel model)
        {
            _unitOfWork.Begin();
            _repository.Create(model);
            _unitOfWork.Commit();
            return model;

        }

        public async Task<ProjectModel> Modify(ProjectModel model)
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
