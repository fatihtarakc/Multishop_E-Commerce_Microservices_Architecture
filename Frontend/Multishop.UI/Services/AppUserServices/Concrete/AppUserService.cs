using Multishop.UI.Models.ViewModels.AppUserVMs;
using Multishop.UI.Services.AppUserServices.Abstract;

namespace Multishop.UI.Services.AppUserServices.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly HttpClient httpClient;
        public AppUserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AppUserVM> GetFirstOrDefaultAsync() =>
            await httpClient.GetFromJsonAsync<AppUserVM>("user/getfirstordefault");
    }
}