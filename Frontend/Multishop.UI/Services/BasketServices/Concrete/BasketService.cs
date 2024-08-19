using Multishop.UI.Models.ViewModels.BasketVMs;
using Multishop.UI.Services.BasketServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.BasketServices.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient httpClient;
        public BasketService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> SaveAsync(BasketVM basketVM) =>
            (await httpClient.PostAsJsonAsync("basket/save", basketVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync() =>
            (await httpClient.DeleteAsync("basket/delete")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<BasketVM> GetFirstOrDefaultAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("basket/get");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<BasketVM>() : null;
        }
    }
}