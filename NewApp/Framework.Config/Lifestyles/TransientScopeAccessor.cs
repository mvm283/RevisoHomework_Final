using System;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Framework.Config.LifeStyles
{
    /// <summary>
    /// Used by the HybridLifeStyleScopeAccessor class to provide the Transient LifeStyle as fallback
    /// </summary>
    public class TransientScopeAccessor : IScopeAccessor
    {
        public ILifetimeScope GetScope(Castle.MicroKernel.Context.CreationContext context)
        {
            return new DefaultLifetimeScope();
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}