using Microsoft.AspNetCore.Mvc;
using RedisProject.RedisService;
using StackExchange.Redis;

namespace RedisProject.Controllers
{
    public class RedisStackExchangeController : Controller
    {
        RedisService.RedisService _redisService;
        public RedisStackExchangeController(RedisService.RedisService redisService)
        {

            _redisService = redisService;
        }

        public void RedisString()
        {
            //IDatabase veritabanındaki nesneleri yönetmek için kullanılır.
            IDatabase database = _redisService.GetDb(1);

            //SET - db'ye key-value değeri atama
            database.StringSet("name", "harun");

            //GET
            string name_value = database.StringGet("name");

            //APPEND
            database.StringAppend("name", "KARAKAYA");
            string append_value = database.StringGet("name");

            //INCR
            database.StringSet("count", 1);
            long value_count = database.StringIncrement("count");

            //GETRANGE
            string value_getrange = database.StringGetRange("name", 2, 4);
        }
    }
}
