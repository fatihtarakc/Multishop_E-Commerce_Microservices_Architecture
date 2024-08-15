using Multishop.UI.Areas.Admin.Models.ViewModels.BrandVMs;
using Multishop.UI.Models.ViewModels.BrandVMs;
using Multishop.UI.Services.BrandServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.BrandServices.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient httpClient;
        public BrandService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(BrandAddVM brandAddVM) =>
            (await httpClient.PostAsJsonAsync("brand/add", brandAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string brandId) =>
            (await httpClient.DeleteAsync($"brand/delete/{brandId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(BrandUpdateVM brandUpdateVM) =>
            (await httpClient.PutAsJsonAsync("brand/update", brandUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<BrandVM> GetFirstOrDefaultAsync(string brandId) 
        {
            var httpResponseMessage = await httpClient.GetAsync($"brand/getby/{brandId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<BrandVM>() : null;
        }

        public async Task<IEnumerable<BrandVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("brand/brands");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<BrandVM>>() : null;
        }
    }
}