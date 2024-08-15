using Multishop.UI.Areas.Admin.Models.ViewModels.OfferVMs;
using Multishop.UI.Models.ViewModels.OfferVMs;
using Multishop.UI.Services.OfferServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.OfferServices.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly HttpClient httpClient;
        public OfferService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(OfferAddVM offerAddVM) =>
            (await httpClient.PostAsJsonAsync("offer/add", offerAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string offerId) =>
            (await httpClient.DeleteAsync($"offer/delete/{offerId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(OfferUpdateVM offerUpdateVM) =>
            (await httpClient.PutAsJsonAsync("offer/update", offerUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<OfferVM> GetFirstOrDefaultAsync(string offerId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"offer/getby/{offerId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<OfferVM>() : null;
        }

        public async Task<IEnumerable<OfferVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("offer/offers");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<OfferVM>>() : null;
        }
    }
}