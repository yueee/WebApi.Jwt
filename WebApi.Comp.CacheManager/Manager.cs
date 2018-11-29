using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Comp.CacheManager
{
   public class Manager
    {
        ICacheManager<object> RuntimeCache = CacheFactory.Build("getStartedCache", settings =>
        {
            settings.WithSystemRuntimeCacheHandle("RuntimeCache");
        });

        public void text()
        {
        }
    }
}
