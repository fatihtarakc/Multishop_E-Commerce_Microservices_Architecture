using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.Abstract
{
    public interface IUserService
    {
        Task<AppUserVM> GetFirstOrDefaultAsync();

        Task<string> RefreshTokenGetFirstOrDefaultAsync();
    }
}