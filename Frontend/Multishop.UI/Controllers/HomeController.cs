using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.CategoryVMs;
using Multishop.UI.Models.ViewModels.HomeVMs;
using Multishop.UI.Services.AdvertisementServices.Abstract;
using Multishop.UI.Services.BrandServices.Abstract;
using Multishop.UI.Services.OfferServices.Abstract;
using Multishop.UI.Services.ServiceServices.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Multishop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisementService advertisementService;
        private readonly IBrandService brandService;
        private readonly IOfferService offerService;
        private readonly IServiceService serviceService;
        private readonly IHttpClientFactory httpClientFactory;
        public HomeController(IAdvertisementService advertisementService, IBrandService brandService, IOfferService offerService, IServiceService serviceService, IHttpClientFactory httpClientFactory)
        {
            this.advertisementService = advertisementService;
            this.brandService = brandService;
            this.offerService = offerService;
            this.serviceService = serviceService;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            string token = "";
            using (var httpclient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:7000/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id", "Multishop.VisitorId" },
                        {"client_secret", "multishop.clientsecret" },
                        {"grant_type", "client_credentials" }
                    })
                };

                using (var response = await httpclient.SendAsync(request)) 
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenresponse = JObject.Parse(content);
                        token = tokenresponse["access_token"].ToString();
                    }
                }
            }
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7001/api/category/categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<IEnumerable<CategoryVM>>(jsondata);

            var advertisementVMs = await advertisementService.GetAllAsync();
            if (advertisementVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var brandVMs = await brandService.GetAllAsync();
            if (brandVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var offerVMs = await offerService.GetAllAsync();
            if (offerVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var serviceVMs = await serviceService.GetAllAsync();
            if (serviceVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

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