using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Models.ViewModels.CategoryVMs;
using Multishop.UI.Services.Abstract;
using System.Net;

namespace Multishop.UI.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;
        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(CategoryAddVM categoryAddVM) =>
            (await httpClient.PostAsJsonAsync<CategoryAddVM>("/category/add", categoryAddVM)).StatusCode == HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string categoryId) =>
            (await httpClient.DeleteAsync($"/category/delete/{categoryId}")).StatusCode == HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(CategoryUpdateVM categoryUpdateVM) =>
            (await httpClient.PutAsJsonAsync<CategoryUpdateVM>("/category/update", categoryUpdateVM)).StatusCode == HttpStatusCode.OK ? true : false;

        public async Task<CategoryVM> GetFirstOrDefaultAsync(string categoryId) =>
            await httpClient.GetFromJsonAsync<CategoryVM>($"/category/getby/{categoryId}");

        public async Task<IEnumerable<CategoryVM>> GetAllAsync() =>
            await httpClient.GetFromJsonAsync<IEnumerable<CategoryVM>>("/category/categories");
    }
}