using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.IdentityServices.Abstract
{
    public interface IIdentityService
    {
        string GetUserId();

        Task<bool> SignInWithTokenAsync(AppUserSignInVM appUserSignInVM);

        Task<bool> SignInWithRefreshTokenAsync();

        Task<HttpResponseMessage> SignUpAsync(AppUserSignUpVM appUserSignUpVM);

        Task<bool> SignOutAsync();

        Task<string> ClientCredentialTokenGetFirstOrDefaultAsync();
    }
}