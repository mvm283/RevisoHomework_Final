using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framwork.Core
{
    public  interface IRepository<TKey,T>
    { 
        List<T> Getall();
        T GetById(TKey id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
