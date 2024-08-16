using StackExchange.Redis;

namespace Multishop.Basket.Services.RedisServices
{
    public interface IRedisService
    {
        public void Connect();
        public IDatabase GetDatabase();
    }
}