using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.Abstract
{
    public interface IAppUserService
    {
        Task<bool> SignInWithTokenAsync(AppUserSignInVM appUserSignInVM);

        Task<bool> SignInWithRefreshTokenAsync();

        Task<AppUserVM> GetFirstOrDefaultAsync();

        Task<string> TokenGetFirstOrDefaultAsync();
    }
}