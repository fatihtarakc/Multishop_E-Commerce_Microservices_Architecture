using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.HomeVMs;
using Multishop.UI.Services.AdvertisementServices.Abstract;
using Multishop.UI.Services.BrandServices.Abstract;
using Multishop.UI.Services.OfferServices.Abstract;
using Multishop.UI.Services.ServiceServices.Abstract;

namespace Multishop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisementService advertisementService;
        private readonly IBrandService brandService;
        private readonly IOfferService offerService;
        private readonly IServiceService serviceService;
        public HomeController(IAdvertisementService advertisementService, IBrandService brandService, IOfferService offerService, IServiceService serviceService)
        {
            this.advertisementService = advertisementService;
            this.brandService = brandService;
            this.offerService = offerService;
            this.serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
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