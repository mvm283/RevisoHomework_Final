using Framwork.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framwork.DataAccess.EF
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T: class
    {
        protected readonly DbContext _dbContext;
        protected BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public virtual void Create(T entity)
        {
             _dbContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
  
        public virtual List<T> Getall()
        {
            return _dbContext.Set<T>().ToList();
        } 

        public  virtual T GetById(TKey id)
        { 
            return _dbContext.Set<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State=EntityState.Modified;

        }
    }
}
