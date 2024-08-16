using Multishop.UI.Models.ViewModels.BasketVMs;

namespace Multishop.UI.Services.BasketServices.Abstract
{
    public interface IBasketService
    {
        Task<bool> SaveAsync(BasketAddVM basketAddVM);
        Task<bool> DeleteAsync(string userId);
        Task<bool> GetFirstOrDefaultAsync(string userId);
    }
}