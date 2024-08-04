using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Models.ViewModels.CategoryVMs;

namespace Multishop.UI.Services.CategoryServices.Abstract
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(CategoryAddVM categoryAddVM);
        Task<bool> DeleteAsync(string categoryId);
        Task<bool> UpdateAsync(CategoryUpdateVM categoryUpdateVM);
        Task<CategoryVM> GetFirstOrDefaultAsync(string categoryId);
        Task<IEnumerable<CategoryVM>> GetAllAsync();
    }
}