using Multishop.UI.Models.ViewModels.AppUserVMs;
using Multishop.UI.Services.Abstract;

namespace Multishop.UI.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly HttpClient httpClient;
        public AppUserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AppUserVM> GetFirstOrDefaultAsync()
        {
            return await httpClient.GetFromJsonAsync<AppUserVM>("/api/user/getfirstordefault");
        }

        public async Task<string> TokenGetFirstOrDefaultAsync()
        {
            return null;
        }

        public async Task<string> RefreshTokenGetFirstOrDefaultAsync()
        {
            return null;
        }
    }
}