using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.AppUserServices.Abstract
{
    public interface IAppUserService
    {
        Task<AppUserVM> GetFirstOrDefaultAsync();
    }
}