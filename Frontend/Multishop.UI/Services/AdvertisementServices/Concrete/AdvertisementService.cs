using Multishop.UI.Areas.Admin.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Services.AdvertisementServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.AdvertisementServices.Concrete
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly HttpClient httpClient;
        public AdvertisementService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(AdvertisementAddVM advertisementAddVM) =>
            (await httpClient.PostAsJsonAsync("/advertisement/add", advertisementAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string advertisementId) =>
            (await httpClient.DeleteAsync($"/advertisement/delete/{advertisementId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(AdvertisementUpdateVM advertisementUpdateVM) =>
            (await httpClient.PutAsJsonAsync("/advertisement/update", advertisementUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<AdvertisementVM> GetFirstOrDefaultAsync(string advertisementId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"/advertisement/getby/{advertisementId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<AdvertisementVM>() : null;
        }

        public async Task<IEnumerable<AdvertisementVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("/advertisement/advertisements");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AdvertisementVM>>() : null;
        }
    }
}