using Multishop.Basket.Dtos.BasketDtos;

namespace Multishop.Basket.Services.BasketServices
{
    public interface IBasketService
    {
        Task<bool> DeleteAsync(string userId);
        Task<bool> SaveChangesAsync(BasketDto basketDto);
        Task<BasketDto> GetByAsync(string userId);
    }
}