using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Services.ContactServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var contactVMs = await contactService.GetAllAsync();
            return View(contactVMs);
        }

        [HttpGet("Admin/Contact/Delete/{contactId}")]
        public async Task<IActionResult> Delete(string contactId)
        {
            bool response = await contactService.DeleteAsync(contactId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Contact/Update/{contactId},{isRead}")]
        public async Task<IActionResult> Update(string contactId, bool isRead)
        {
            bool response = await contactService.UpdateAsync(contactId, isRead);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}