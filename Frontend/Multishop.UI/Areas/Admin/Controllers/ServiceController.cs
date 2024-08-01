using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.ServiceVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Service/Services");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var serviceVMs = JsonConvert.DeserializeObject<IEnumerable<UI.Models.ViewModels.ServiceVMs.ServiceVM>>(jsonData);
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

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(serviceAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Service/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Service/Delete/{serviceId}")]
        public async Task<IActionResult> Delete(string serviceId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Service/Delete/{serviceId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Service/Update/{serviceId}")]
        public async Task<IActionResult> Update(string serviceId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Service/GetBy/{serviceId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var serviceUpdateVM = JsonConvert.DeserializeObject<ServiceUpdateVM>(jsonData);
            return View(serviceUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ServiceUpdateVM serviceUpdateVM)
        {
            if (!ModelState.IsValid) return View(serviceUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(serviceUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Service/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}