using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.ProductVMs;
using Newtonsoft.Json;

namespace Multishop.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ShopController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet("/Shop/Index/{categoryId}")]
        public async Task<IActionResult> Index(string categoryId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/ProductsGetBy/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productVMs = JsonConvert.DeserializeObject<IEnumerable<ProductVM>>(jsonData);
            return View(productVMs);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}