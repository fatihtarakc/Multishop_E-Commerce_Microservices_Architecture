using Multishop.UI.Areas.Admin.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Models.ViewModels.AdvertisementVMs;

namespace Multishop.UI.Services.AdvertisementServices.Abstract
{
    public interface IAdvertisementService
    {
        Task<bool> AddAsync(AdvertisementAddVM advertisementAddVM);
        Task<bool> DeleteAsync(string advertisementId);
        Task<bool> UpdateAsync(AdvertisementUpdateVM advertisementUpdateVM);
        Task<AdvertisementVM> GetFirstOrDefaultAsync(string advertisementId);
        Task<IEnumerable<AdvertisementVM>> GetAllAsync();
    }
}