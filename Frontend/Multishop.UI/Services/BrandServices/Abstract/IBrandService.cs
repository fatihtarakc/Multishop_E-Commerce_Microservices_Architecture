using Multishop.UI.Areas.Admin.Models.ViewModels.BrandVMs;
using Multishop.UI.Models.ViewModels.BrandVMs;

namespace Multishop.UI.Services.BrandServices.Abstract
{
    public interface IBrandService
    {
        Task<bool> AddAsync(BrandAddVM brandAddVM);
        Task<bool> DeleteAsync(string brandId);
        Task<bool> UpdateAsync(BrandUpdateVM brandUpdateVM);
        Task<BrandVM> GetFirstOrDefaultAsync(string brandId);
        Task<IEnumerable<BrandVM>> GetAllAsync();
    }
}