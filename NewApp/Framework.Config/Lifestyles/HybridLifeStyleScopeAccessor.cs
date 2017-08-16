using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Framework.Config.LifeStyles
{
    /// <summary>     
    /// Custom LifeStyle to automatically detect the context in which the application is being used and return appropriate scope for the objects. Following is the order in which scopes are detected and the first one found is returned:     
    /// - WCF Operation     
    /// - Web Request     
    /// - Transient
    /// </summary>
    /// <remarks>        
    /// <para>     
    /// No new scope is implemented, it just  provides a Hybrid model for scopes provided by Castle Windsor and WCF Integration Factility.     
    /// </para>     
    /// <para>      
    /// Primarily introduced so that the Data Access code using NHibernate Sessions can work within WCF Operation as well as Web Request.     
    /// </para>     
    /// <para>     
    /// Following configuration must be added to web.config for the WebRequest Lifetime Scope to work:     
    /// <configuration>     
    ///     <system.webServer>     
    ///         <modules>     
    ///             <add name="PerRequestLifestyle" type="Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.Windsor" />     
    ///         </modules>     
    ///     </system.webServer>     
    /// </configuration>     
    /// </para>     
    /// </remarks> 
    public class HybridLifeStyleScopeAccessor : IScopeAccessor
    {
        private readonly IScopeAccessor _WcfOperationScopeAccessor = new Castle.Facilities.WcfIntegration.Lifestyles.WcfOperationScopeAccessor();
        private readonly IScopeAccessor _WebRequestScopeAccessor = new Castle.MicroKernel.Lifestyle.WebRequestScopeAccessor();
        private readonly IScopeAccessor _TransientScopeAccessor = new TransientScopeAccessor();

        ///<summary> 
        /// If Wcf Opertaion Context is available then returns WcfOperation Lifetime Scope
        /// Else If HttpContext is avilable then return WebRequest Lifetime Scope
        /// Else Returns Transient LifetimeScope
        /// </summary>
        public ILifetimeScope GetScope(Castle.MicroKernel.Context.CreationContext context)
        {
            if (OperationContext.Current != null)
                return this._WcfOperationScopeAccessor.GetScope(context);
            else if (HttpContext.Current != null)
                return this._WebRequestScopeAccessor.GetScope(context);
            else
                return this._TransientScopeAccessor.GetScope(context);
        }

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this._TransientScopeAccessor.Dispose();
                    this._WcfOperationScopeAccessor.Dispose();
                    this._WebRequestScopeAccessor.Dispose();
                }
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
