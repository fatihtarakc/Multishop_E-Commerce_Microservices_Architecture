using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;
using Multishop.UI.Models.ViewModels.ImageVMs;
using Multishop.UI.Services.ImageServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.ImageServices.Concrete
{
    public class ImageService : IImageService
    {
        private readonly HttpClient httpClient;
        public ImageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(ImageAddVM imageAddVM) =>
            (await httpClient.PostAsJsonAsync("image/add", imageAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string imageId) =>
            (await httpClient.DeleteAsync($"image/delete/{imageId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(ImageUpdateVM imageUpdateVM) =>
            (await httpClient.PutAsJsonAsync("image/update", imageUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<ImageVM> GetFirstOrDefaultAsync(string imageId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"image/getby/{imageId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<ImageVM>() : null;
        }

        public async Task<IEnumerable<ImageVM>> GetAllByAsync(string productId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"image/imagesgetby/{productId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ImageVM>>() : null;
        }
    }
}