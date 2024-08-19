using Multishop.UI.Models.ViewModels.BasketVMs;

namespace Multishop.UI.Services.BasketServices.Abstract
{
    public interface IBasketService
    {
        Task<bool> SaveAsync(BasketVM basketVM);
        Task<bool> DeleteAsync();
        Task<BasketVM> GetFirstOrDefaultAsync();
    }
}