using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text;

namespace RedisProject.Controllers
{
    public class DistributedCacheManager
    {
        IDistributedCache _distributedCache;

        public DistributedCacheManager(IDistributedCache distributedCache)
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

        public void CacheGetString()
        {
            //Metinsel türde depolanmış verilerden key değerine karşılık value değerini döndüren fonksiyondur.
            string value = _distributedCache.GetString("date");
        }

        public void CacheRemove()
        {
            //Key değeri verilen datayı silen metottur.
            _distributedCache.Remove("date");
        }


    }
}
