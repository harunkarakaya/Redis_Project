using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace RedisProject.Controllers
{
    public class DistributedCache
    {
        IDistributedCache _distributedCache;

        public DistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void CacheSetString()
        {
            //Metinsel türde key-value tarzında veri depolamasını gerçekleştiren metottur.
            _distributedCache.SetString("date", DateTime.Now.ToString());
        }

        public void CacheSetString2() //Alternatifi
        {
            _distributedCache.SetString("date", DateTime.Now.ToString(), new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(1200),
                SlidingExpiration = TimeSpan.FromSeconds(60)
            });
        }
    }
}
