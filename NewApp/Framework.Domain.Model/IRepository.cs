using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Model
{
    public interface IRepository
    {
        
    }
    public interface IRepository<TKey, T> : IRepository where T : class,IAggregateRoot 
    {
        Task<T> Get(TKey id);
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        void Create(T aggregate);
        void Delete(T aggregate);
        Task Update(T aggregate);
        void Delete(Expression<Func<T, bool>> predicate);
        TKey GetNextId();
    }
}
