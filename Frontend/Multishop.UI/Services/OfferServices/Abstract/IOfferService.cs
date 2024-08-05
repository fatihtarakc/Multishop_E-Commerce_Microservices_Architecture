using Multishop.UI.Areas.Admin.Models.ViewModels.OfferVMs;
using Multishop.UI.Models.ViewModels.OfferVMs;

namespace Multishop.UI.Services.OfferServices.Abstract
{
    public interface IOfferService
    {
        Task<bool> AddAsync(OfferAddVM offerAddVM);
        Task<bool> DeleteAsync(string offerId);
        Task<bool> UpdateAsync(OfferUpdateVM offerUpdateVM);
        Task<OfferVM> GetFirstOrDefaultAsync(string offerId);
        Task<IEnumerable<OfferVM>> GetAllAsync();
    }
}