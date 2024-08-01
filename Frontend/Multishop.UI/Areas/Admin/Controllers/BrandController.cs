using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.BrandVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BrandController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Brand/Brands");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var brandVMs = JsonConvert.DeserializeObject<IEnumerable<UI.Models.ViewModels.BrandVMs.BrandVM>>(jsonData);
            return View(brandVMs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BrandAddVM brandAddVM)
        {
            if (!ModelState.IsValid) return View(brandAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(brandAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Brand/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Brand/Delete/{brandId}")]
        public async Task<IActionResult> Delete(string brandId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Brand/Delete/{brandId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Brand/Update/{brandId}")]
        public async Task<IActionResult> Update(string brandId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Brand/GetBy/{brandId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var brandUpdateVM = JsonConvert.DeserializeObject<BrandUpdateVM>(jsonData);
            return View(brandUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BrandUpdateVM brandUpdateVM)
        {
            if (!ModelState.IsValid) return View(brandUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(brandUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Brand/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}