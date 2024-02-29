using Microsoft.AspNetCore.Mvc;
using RedisProject.RedisService;
using StackExchange.Redis;
using System.Linq;
using System.Web;

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

        public void RedisList()
        {
            IDatabase database = _redisService.GetDb(1);

            //LPUSH - ön taraftan ekleme
            database.ListLeftPush("ogrenciler", "furkan");
            database.ListLeftPush("ogrenciler", "hakan");
            database.ListLeftPush("ogrenciler", "aleyna");

            //RPUSH - arka taraftan ekleme
            database.ListRightPush("ogrenciler", "emine");
            database.ListRightPush("ogrenciler", "kevser");
            database.ListRightPush("ogrenciler", "murat");

            //LRANGE
            RedisValue[] values = database.ListRange("ogrenciler", 0, -1);
            int count = 1;

            //LPOP - baştan ilk öğrenci
            string left_pop = database.ListLeftPop("ogrenciler");

            //RPOP - sondan ilk öğrenci
            string right_pop = database.ListRightPop("ogrenciler");

            //LINDEX - sondan getiriyor
            string index_value = database.ListGetByIndex("ogrenciler", 2);
        }

        public void RedisSet()
        {
            IDatabase database = _redisService.GetDb(1);
            //Set add
            database.SetAdd("color", "blue");
            database.SetAdd("color", "red");
            database.SetAdd("color", "white");
            database.SetAdd("color", "black");

            //Set Members
            RedisValue[] values = database.SetMembers("color");

            //Set Remove
            database.SetRemove("color", "white");
            values = database.SetMembers("color");
        }

        public void RedisSortedSet()
        {
            IDatabase database = _redisService.GetDb(1);

            //Z ADD
            database.SortedSetAdd("esya", "kalem", 5);
            database.SortedSetAdd("esya", "silgi", 10);
            database.SortedSetAdd("esya", "defter", 15);
            database.SortedSetAdd("esya", "kağıt", 2);

            //ZRANGE
            RedisValue[] values = database.SortedSetRangeByRank("esya", 0, -1);

            //ZREM
            database.SortedSetRemove("esya", "kalem");
            values = database.SortedSetRangeByRank("esya", 0, -1);
        }
    }
}
