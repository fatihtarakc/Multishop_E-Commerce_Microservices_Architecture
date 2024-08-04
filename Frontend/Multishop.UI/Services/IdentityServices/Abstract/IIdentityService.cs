using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.IdentityServices.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignInWithTokenAsync(AppUserSignInVM appUserSignInVM);

        Task<bool> SignInWithRefreshTokenAsync();

        Task<AppUserVM> GetFirstOrDefaultAsync();

        Task<string> ClientCredentialTokenGetFirstOrDefaultAsync();
    }
}