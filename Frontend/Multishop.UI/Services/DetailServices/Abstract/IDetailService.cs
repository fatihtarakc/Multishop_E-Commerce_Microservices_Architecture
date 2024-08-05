using Multishop.UI.Areas.Admin.Models.ViewModels.DetailVMs;
using Multishop.UI.Models.ViewModels.DetailVMs;

namespace Multishop.UI.Services.DetailServices.Abstract
{
    public interface IDetailService
    {
        Task<bool> AddAsync(DetailAddVM detailAddVM);
        Task<bool> DeleteAsync(string detailId);
        Task<bool> UpdateAsync(DetailUpdateVM detailUpdateVM);
        Task<DetailVM> GetFirstOrDefaultAsync(string productId);
    }
}