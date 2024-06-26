using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.CategoryVMs;
using Newtonsoft.Json;

namespace Multishop.UI.ViewComponents.Layout
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _NavbarPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryVM>>(jsonData);
            return View(categoryVMs);
        }
    }
}