using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Models.ViewModels.HomeVMs;
using Multishop.UI.Models.ViewModels.OfferVMs;
using Newtonsoft.Json;

namespace Multishop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Advertisement/Advertisements");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var advertisementVMs = JsonConvert.DeserializeObject<IEnumerable<AdvertisementVM>>(jsonData);

            responseMessage = await client.GetAsync("https://localhost:7001/api/Offer/Offers");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var offerVMs = JsonConvert.DeserializeObject<IEnumerable<OfferVM>>(jsonData);

            var homeVM = new HomeVM()
            {
                AdvertisementVMs = advertisementVMs,
                OfferVMs = offerVMs
            };
            return View(homeVM);
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}