using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.Abstract
{
    public interface IAppUserService
    {
        Task<bool> SignInAsync(AppUserSignInVM appUserSignInVM);

        Task<AppUserVM> GetFirstOrDefaultAsync();

        Task<string> TokenGetFirstOrDefaultAsync();

        Task<string> RefreshTokenGetFirstOrDefaultAsync();
    }
}