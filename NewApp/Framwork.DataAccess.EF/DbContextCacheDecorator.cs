using Framwork.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Framwork.DataAccess.EF
{
    public class DbContextCacheDecorator : DbContext
    {
        private ICachKeyContainer _cacheKeyContainer;
        private ICachManager _cachManager;
        private List<string> keysForExpire = new List<string>();

        private DbContext context;
        public DbContextCacheDecorator()
        {

        }
        public DbContextCacheDecorator(DbContext dbContext, ICachKeyContainer cacheKeyContainer, ICachManager cachManager)
        {
            this.context = dbContext; 

            _cacheKeyContainer = cacheKeyContainer;
            _cachManager = cachManager;

            var context = ((IObjectContextAdapter) this.context).ObjectContext;
            context.SavingChanges += ContextOnSavingChanges;
        } 
        
        public override int SaveChanges()
        {  
            var output = context.SaveChanges();
            ExpireCache();
            return output;
        }

        private void ExpireCache()
        {
            keysForExpire.Distinct().ToList().ForEach(a => _cachManager.Expire(a));
            keysForExpire = new List<string>();
        }
        private void ContextOnSavingChanges(Object sender, EventArgs args)
        {
            var changes = (sender as ObjectContext).ObjectStateManager.GetObjectStateEntries
                (EntityState.Added | EntityState.Modified | EntityState.Deleted);

            //foreach (var entry in changes)
            //{
            //    var casheKeys = _cacheKeyContainer.Detect(entry.Entity.GetType()).ToList();
            //    keysForExpire.AddRange(casheKeys);
            //}
        }
    }
}
