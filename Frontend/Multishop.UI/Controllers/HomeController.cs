using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Models.ViewModels.BrandVMs;
using Multishop.UI.Models.ViewModels.HomeVMs;
using Multishop.UI.Models.ViewModels.OfferVMs;
using Multishop.UI.Models.ViewModels.ServiceVMs;
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

            responseMessage = await client.GetAsync("https://localhost:7001/api/Brand/Brands");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var brandVMs = JsonConvert.DeserializeObject<IEnumerable<BrandVM>>(jsonData);

            responseMessage = await client.GetAsync("https://localhost:7001/api/Offer/Offers");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var offerVMs = JsonConvert.DeserializeObject<IEnumerable<OfferVM>>(jsonData);

            responseMessage = await client.GetAsync("https://localhost:7001/api/Service/Services");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var serviceVMs = JsonConvert.DeserializeObject<IEnumerable<ServiceVM>>(jsonData);

            var homeVM = new HomeVM()
            {
                AdvertisementVMs = advertisementVMs,
                BrandVMs = brandVMs,
                OfferVMs = offerVMs,
                ServiceVMs = serviceVMs
            };
            return View(homeVM);
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}