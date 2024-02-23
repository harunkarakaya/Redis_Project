using StackExchange.Redis;

namespace RedisProject.RedisService
{
    public class RedisService
    {
        ConnectionMultiplexer connectionMultiplexer;
        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379"); //redis sunucusuna bağlantı gerçekleştiriliyor.
        public IDatabase GetDb(int db) => connectionMultiplexer.GetDatabase(db);
    }
}
