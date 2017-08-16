using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Model
{
    public abstract class BaseValueObject<T> : IValueObject<T> where T : class
    {
        //public virtual bool SameValueAs(T valueObject)
        //{
        //    return EqualsBuilder.ReflectionEquals(this, valueObject);
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    return SameValueAs(obj as T);
        //}
        //public override int GetHashCode()
        //{
        //    return HashCodeBuilder.ReflectionHashCode(this);
        //}
        public bool SameValueAs(T valueObject)
        {
            throw new NotImplementedException();
        }
    }
}