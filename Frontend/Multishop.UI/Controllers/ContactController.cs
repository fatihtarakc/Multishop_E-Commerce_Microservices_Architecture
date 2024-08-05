using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.ContactVMs;
using Multishop.UI.Services.ContactServices.Abstract;

namespace Multishop.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ContactAddVM contactAddVM)
        {
            if (!ModelState.IsValid) return View(contactAddVM);

            bool response = await contactService.AddAsync(contactAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}