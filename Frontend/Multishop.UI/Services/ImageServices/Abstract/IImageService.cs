using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;
using Multishop.UI.Models.ViewModels.ImageVMs;

namespace Multishop.UI.Services.ImageServices.Abstract
{
    public interface IImageService
    {
        Task<bool> AddAsync(ImageAddVM imageAddVM);
        Task<bool> DeleteAsync(string imageId);
        Task<bool> UpdateAsync(ImageUpdateVM imageUpdateVM);
        Task<ImageVM> GetFirstOrDefaultAsync(string imageId);
        Task<IEnumerable<ImageVM>> GetAllByAsync(string productId);
    }
}