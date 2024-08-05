using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;
using Multishop.UI.Models.ViewModels.ProductVMs;
using Multishop.UI.Services.ProductServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.ProductServices.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(ProductAddVM productAddVM) =>
            (await httpClient.PostAsJsonAsync("/product/add", productAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string productId) =>
            (await httpClient.DeleteAsync($"/product/delete/{productId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(ProductUpdateVM productUpdateVM) =>
            (await httpClient.PutAsJsonAsync("/product/update", productUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<ProductVM> GetFirstOrDefaultAsync(string productId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"/product/getby/{productId}");
            if (httpResponseMessage.StatusCode is not HttpStatusCode.OK) return null;

            return await httpResponseMessage.Content.ReadFromJsonAsync<ProductVM>();
        }

        public async Task<IEnumerable<ProductVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("/product/products");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductVM>>() : null;
        }

        public async Task<IEnumerable<ProductVM>> GetAllByAsync(string categoryId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"/product/productsgetby/{categoryId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductVM>>() : null;
        }
    }
}