using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Product/Products");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productListVMs = JsonConvert.DeserializeObject<IEnumerable<ProductListVM>>(jsonData);
            return View(productListVMs);
        }

        public async Task<IActionResult> Add()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryListVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryListVM>>(jsonData);
            IEnumerable<SelectListItem> categories = (from category in categoryListVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductAddVM productAddVM)
        {
            if (!ModelState.IsValid) return View(productAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Product/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Delete/{productId}")]
        public async Task<IActionResult> Delete(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Product/Delete/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Update/{productId}")]
        public async Task<IActionResult> Update(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryListVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryListVM>>(jsonData);
            IEnumerable<SelectListItem> categories = (from category in categoryListVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;

            client = httpClientFactory.CreateClient();
            responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/GetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productUpdateVM = JsonConvert.DeserializeObject<ProductUpdateVM>(jsonData);
            return View(productUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateVM productUpdateVM)
        {
            if (!ModelState.IsValid) return View(productUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Product/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}