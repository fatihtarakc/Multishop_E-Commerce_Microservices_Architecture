using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.ContactVMs;
using Newtonsoft.Json;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Contact/Contacts");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var contactVMs = JsonConvert.DeserializeObject<IEnumerable<ContactVM>>(jsonData);
            return View(contactVMs);
        }

        [HttpGet("Admin/Contact/Delete/{contactId}")]
        public async Task<IActionResult> Delete(string contactId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Contact/Delete/{contactId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Contact/Update/{contactId},{isRead}")]
        public async Task<IActionResult> Update(string contactId, bool isRead)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:7001/api/Contact/Update/{contactId},{isRead}", null);
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}