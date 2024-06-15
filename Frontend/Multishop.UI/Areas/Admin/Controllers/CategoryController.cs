using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryVM>>(jsonData);
            return View(categoryVMs);
        }

        [HttpGet("Admin/Category/Detail/{categoryId}")]
        public async Task<IActionResult> Detail(string categoryId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Category/GetBy/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVM = JsonConvert.DeserializeObject<CategoryVM>(jsonData);

            responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/ProductsGetBy/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productVMs = JsonConvert.DeserializeObject<IEnumerable<ProductVM>>(jsonData);

            var categoryProductsVM = new CategoryProductsVM();
            categoryProductsVM.CategoryVM = categoryVM;
            categoryProductsVM.ProductVMs = productVMs;
            return View(categoryProductsVM);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryAddVM categoryAddVM)
        {
            if (!ModelState.IsValid) return View(categoryAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Category/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Category/Delete/{categoryId}")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Category/Delete/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Category/Update/{categoryId}")]
        public async Task<IActionResult> Update(string categoryId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Category/GetBy/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryUpdateVM = JsonConvert.DeserializeObject<CategoryUpdateVM>(jsonData);
            return View(categoryUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryUpdateVM categoryUpdateVM)
        {
            if (!ModelState.IsValid) return View(categoryUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Category/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}