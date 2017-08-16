using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Model
{
    public abstract class EntityBase<TKey, T> where T : EntityBase<TKey, T>
    {
        public virtual TKey Id { get; protected set; }
        public virtual bool SameAs(T entity)
        {
            if (entity == null) return false;
            return entity.Id.Equals(this.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return SameAs(obj as T);
        }
         
    }
}
