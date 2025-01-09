using StackExchange.Redis;

namespace CIdentity.Services
{
    public class RedisService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task SetDataAsync(string key, string value)
        {
            var db = _redis.GetDatabase();
            await db.StringSetAsync(key, value);
        }

        public async Task<string> GetDataAsync(string key)
        {
            var db = _redis.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task<string> GetAllKey()
        {
            var server = _redis.GetServer("192.168.1.14", 6379);
            var keys = server.Keys();
            foreach(var key in keys)
            {
                Console.WriteLine(key);
            }
            return "keys";
        }
    }
}
