using Mapster;
using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.BrandVMs;
using Multishop.UI.Services.BrandServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;
        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var brandVMs = await brandService.GetAllAsync();
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

            bool response = await brandService.AddAsync(brandAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Brand/Delete/{brandId}")]
        public async Task<IActionResult> Delete(string brandId)
        {
            bool response = await brandService.DeleteAsync(brandId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Brand/Update/{brandId}")]
        public async Task<IActionResult> Update(string brandId)
        {
            var brandUpdateVM = (await brandService.GetFirstOrDefaultAsync(brandId)).Adapt<BrandUpdateVM>();
            if (brandUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(brandUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BrandUpdateVM brandUpdateVM)
        {
            if (!ModelState.IsValid) return View(brandUpdateVM);

            bool response = await brandService.UpdateAsync(brandUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}