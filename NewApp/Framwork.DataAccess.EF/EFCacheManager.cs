using Framwork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Caching;

namespace Framwork.DataAccess.EF
{
    public class EFCacheManager : ICachManager
    {
        public void Expire(params string[] tags)
        {
            foreach (var t in tags)
            {
                CacheManager.Current.Expire(t);
            }
        }
    }
}
