using Mapster;
using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.ServiceVMs;
using Multishop.UI.Services.ServiceServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService serviceService;
        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var serviceVMs = await serviceService.GetAllAsync();
            return View(serviceVMs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ServiceAddVM serviceAddVM)
        {
            if (!ModelState.IsValid) return View(serviceAddVM);

            bool response = await serviceService.AddAsync(serviceAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Service/Delete/{serviceId}")]
        public async Task<IActionResult> Delete(string serviceId)
        {
            bool response = await serviceService.DeleteAsync(serviceId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Service/Update/{serviceId}")]
        public async Task<IActionResult> Update(string serviceId)
        {
            var serviceUpdateVM = (await serviceService.GetFirstOrDefaultAsync(serviceId)).Adapt<ServiceUpdateVM>();
            if (serviceUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(serviceUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ServiceUpdateVM serviceUpdateVM)
        {
            if (!ModelState.IsValid) return View(serviceUpdateVM);

            bool response = await serviceService.UpdateAsync(serviceUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}