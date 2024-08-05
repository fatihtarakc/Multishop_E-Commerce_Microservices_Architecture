using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;
using Multishop.UI.Models.ViewModels.ProductVMs;

namespace Multishop.UI.Services.ProductServices.Abstract
{
    public interface IProductService
    {
        Task<bool> AddAsync(ProductAddVM productAddVM);
        Task<bool> DeleteAsync(string productId);
        Task<bool> UpdateAsync(ProductUpdateVM productUpdateVM);
        Task<ProductVM> GetFirstOrDefaultAsync(string productId);
        Task<IEnumerable<ProductVM>> GetAllAsync();
        Task<IEnumerable<ProductVM>> GetAllByAsync(string categoryId);
    }
}