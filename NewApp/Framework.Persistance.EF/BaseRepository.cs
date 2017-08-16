using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Domain.Model;
using System.Linq.Expressions;
using System.Data;
using Newtonsoft.Json;
using Framework.Web.Kendo.Helpers;
using System.Linq.Dynamic;


namespace Framework.Persistance.EF
{
    public abstract class BaseRepository<TKey, T> : IRepository<TKey, T> where T : class, IAggregateRoot 
    {
        protected readonly DbContext Context;
        protected BaseRepository(DbContext context)
        {
            this.Context = context;
        }

        

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }
        public  async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }
        public async virtual Task<T> Get(TKey id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public  void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public virtual void  Delete(Expression<Func<T, bool>> predicate)
        {
            var forDel=Context.Set<T>().Where(predicate).First();
            Context.Set<T>().Remove(forDel);
        }
        public async virtual Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

          public abstract TKey GetNextId();







    }
}
