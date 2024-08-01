using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.OfferVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public OfferController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Offer/Offers");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var offerVMs = JsonConvert.DeserializeObject<IEnumerable<UI.Models.ViewModels.OfferVMs.OfferVM>>(jsonData);
            return View(offerVMs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(OfferAddVM offerAddVM)
        {
            if (!ModelState.IsValid) return View(offerAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(offerAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Offer/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Offer/Delete/{offerId}")]
        public async Task<IActionResult> Delete(string offerId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Offer/Delete/{offerId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Offer/Update/{offerId}")]
        public async Task<IActionResult> Update(string offerId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Offer/GetBy/{offerId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var offerUpdateVM = JsonConvert.DeserializeObject<OfferUpdateVM>(jsonData);
            return View(offerUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OfferUpdateVM offerUpdateVM)
        {
            if (!ModelState.IsValid) return View(offerUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(offerUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Offer/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}