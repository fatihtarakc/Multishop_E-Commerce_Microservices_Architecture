using Multishop.UI.Models.ViewModels.AppUserVMs;
using Multishop.UI.Services.Abstract;

namespace Multishop.UI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AppUserVM> GetFirstOrDefaultAsync()
        {
            return await httpClient.GetFromJsonAsync<AppUserVM>("/api/user/getfirstordefault");
        }

        public async Task<string> RefreshTokenGetFirstOrDefaultAsync()
        {
            return null;
        }
    }
}