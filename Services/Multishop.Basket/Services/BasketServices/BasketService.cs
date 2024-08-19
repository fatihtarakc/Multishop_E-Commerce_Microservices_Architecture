using Multishop.Basket.Dtos.BasketDtos;
using Multishop.Basket.Services.RedisServices;
using System.Text.Json;

namespace Multishop.Basket.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IRedisService redisService;
        public BasketService(IRedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task<bool> SaveAsync(BasketDto basketDto) =>
            await redisService.GetDatabase().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

        public async Task<bool> DeleteAsync(string userId) =>
            await redisService.GetDatabase().KeyDeleteAsync(userId);

        public async Task<BasketDto> GetByIdAsync(string userId) =>
            JsonSerializer.Deserialize<BasketDto>(await redisService.GetDatabase().StringGetAsync(userId));
    }
}