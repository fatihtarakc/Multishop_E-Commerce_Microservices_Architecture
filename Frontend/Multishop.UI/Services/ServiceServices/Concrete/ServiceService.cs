using Multishop.UI.Areas.Admin.Models.ViewModels.ServiceVMs;
using Multishop.UI.Models.ViewModels.ServiceVMs;
using Multishop.UI.Services.ServiceServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.ServiceServices.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient httpClient;
        public ServiceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(ServiceAddVM serviceAddVM) =>
            (await httpClient.PostAsJsonAsync("service/add", serviceAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string serviceId) =>
            (await httpClient.DeleteAsync($"service/delete/{serviceId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(ServiceUpdateVM serviceUpdateVM) =>
            (await httpClient.PutAsJsonAsync("service/update", serviceUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<ServiceVM> GetFirstOrDefaultAsync(string serviceId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"service/getby/{serviceId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<ServiceVM>() : null;
        }

        public async Task<IEnumerable<ServiceVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("service/services");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ServiceVM>>() : null;
        }
    }
}