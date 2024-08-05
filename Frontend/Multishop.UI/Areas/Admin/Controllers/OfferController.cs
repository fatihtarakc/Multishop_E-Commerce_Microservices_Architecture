using Mapster;
using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.OfferVMs;
using Multishop.UI.Services.OfferServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;
        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            var offerVMs = await offerService.GetAllAsync();
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

            bool response = await offerService.AddAsync(offerAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Offer/Delete/{offerId}")]
        public async Task<IActionResult> Delete(string offerId)
        {
            bool response = await offerService.DeleteAsync(offerId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Offer/Update/{offerId}")]
        public async Task<IActionResult> Update(string offerId)
        {
            var offerUpdateVM = (await offerService.GetFirstOrDefaultAsync(offerId)).Adapt<OfferUpdateVM>();
            if (offerUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(offerUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OfferUpdateVM offerUpdateVM)
        {
            if (!ModelState.IsValid) return View(offerUpdateVM);

            bool response = await offerService.UpdateAsync(offerUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}