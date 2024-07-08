using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.ContactVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
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

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(contactAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Contact/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");
            else ModelState.AddModelError("Error", "Your messages was sent successfully !");

            return RedirectToAction("Index");
        }
    }
}