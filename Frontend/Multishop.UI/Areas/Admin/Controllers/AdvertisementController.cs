using Mapster;
using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Services.AdvertisementServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService advertisementService;
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            this.advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var advertisementVMs = await advertisementService.GetAllAsync();
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

            bool response = await advertisementService.AddAsync(advertisementAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Advertisement/Delete/{advertisementId}")]
        public async Task<IActionResult> Delete(string advertisementId)
        {
            bool response = await advertisementService.DeleteAsync(advertisementId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Advertisement/Update/{advertisementId}")]
        public async Task<IActionResult> Update(string advertisementId)
        {
            var advertisementUpdateVM = (await advertisementService.GetFirstOrDefaultAsync(advertisementId)).Adapt<AdvertisementUpdateVM>();
            if (advertisementUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(advertisementUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdvertisementUpdateVM advertisementUpdateVM)
        {
            if (!ModelState.IsValid) return View(advertisementUpdateVM);

            bool response = await advertisementService.UpdateAsync(advertisementUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}