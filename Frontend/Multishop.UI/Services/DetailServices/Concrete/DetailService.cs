using Multishop.UI.Areas.Admin.Models.ViewModels.DetailVMs;
using Multishop.UI.Models.ViewModels.DetailVMs;
using Multishop.UI.Services.DetailServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.DetailServices.Concrete
{
    public class DetailService : IDetailService
    {
        private readonly HttpClient httpClient;
        public DetailService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(DetailAddVM detailAddVM) =>
            (await httpClient.PostAsJsonAsync("/detail/add", detailAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string detailId) =>
            (await httpClient.DeleteAsync($"/detail/delete/{detailId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(DetailUpdateVM detailUpdateVM) =>
            (await httpClient.PutAsJsonAsync("/detail/update", detailUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<DetailVM> GetFirstOrDefaultAsync(string productId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"/detail/getby/{productId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound ? await httpResponseMessage.Content.ReadFromJsonAsync<DetailVM>() : null;
        }
    }
}