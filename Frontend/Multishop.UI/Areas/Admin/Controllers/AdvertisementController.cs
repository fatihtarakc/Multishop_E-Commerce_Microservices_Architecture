using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.AdvertisementVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvertisementController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AdvertisementController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Advertisement/Advertisements");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var advertisementVMs = JsonConvert.DeserializeObject<IEnumerable<UI.Models.ViewModels.AdvertisementVMs.AdvertisementVM>>(jsonData);
            return View(advertisementVMs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AdvertisementAddVM advertisementAddVM)
        {
            if (!ModelState.IsValid) return View(advertisementAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(advertisementAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Advertisement/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Advertisement/Delete/{advertisementId}")]
        public async Task<IActionResult> Delete(string advertisementId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Advertisement/Delete/{advertisementId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Advertisement/Update/{advertisementId}")]
        public async Task<IActionResult> Update(string advertisementId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Advertisement/GetBy/{advertisementId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var advertisementUpdateVM = JsonConvert.DeserializeObject<AdvertisementUpdateVM>(jsonData);
            return View(advertisementUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdvertisementUpdateVM advertisementUpdateVM)
        {
            if (!ModelState.IsValid) return View(advertisementUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(advertisementUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Advertisement/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}