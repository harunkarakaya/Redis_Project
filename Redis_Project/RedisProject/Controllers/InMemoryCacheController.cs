using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace RedisProject.Controllers
{
    public class InMemoryCacheController : Controller
    {
        IMemoryCache _memoryCache;
        public InMemoryCacheController(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
        }

        public void SetCache()
        {
            _memoryCache.Set("sehir", "bursa");
        }

        public void GetCache()
        {
            string value = _memoryCache.Get<string>("sehir");
        }

        public void RemoveCache()
        {
            //cachelenmiş datayı silmek için kullanılır.
            _memoryCache.Remove("employeeName");
        }

        public void TryGetValue()
        {
            //Cache’de belirtilen key değerine uygun veriyi sorgular.Veri yoksa ‘false’ eğer varsa ‘true’ döner.
            if (_memoryCache.TryGetValue<string>("employeeName", out string data))
            {
                //data burada elde edilmiştir
            }
        }

        public void GetOrCreate() //Belirtilen key değerinde data var mı kontrol eder, yoksa oluşturur.
        {
            string name = _memoryCache.GetOrCreate<string>("employeeName", entry =>
            {
                entry.SetValue("Okan Buruk");
                entry.Value.ToString(); //return
            });
        }
    }
}
