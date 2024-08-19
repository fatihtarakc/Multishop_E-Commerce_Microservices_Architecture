using Multishop.Basket.Dtos.BasketDtos;

namespace Multishop.Basket.Services.BasketServices
{
    public interface IBasketService
    {
        Task<bool> SaveAsync(BasketDto basketDto);
        Task<bool> DeleteAsync(string userId);
        Task<BasketDto> GetByIdAsync(string userId);
    }
}