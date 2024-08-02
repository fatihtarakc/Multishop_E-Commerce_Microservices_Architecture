using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.Services.Abstract
{
    public interface IAppUserService
    {
        Task<AppUserVM> GetFirstOrDefaultAsync();

        Task<string> TokenGetFirstOrDefaultAsync();

        Task<string> RefreshTokenGetFirstOrDefaultAsync();
    }
}