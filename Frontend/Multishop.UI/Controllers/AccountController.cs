using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.AppUserVMs;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(AppUserSignInVM appUserSignInVM)
        {
            if (!ModelState.IsValid) return View(appUserSignInVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(appUserSignInVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7000/api/Account/SignIn", stringContent);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) return RedirectToAction("SignIn");

            else if (responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest) ModelState.AddModelError("", "Email or password is incorrect !");

            else ModelState.AddModelError("", "Something went wrong !");

            return RedirectToAction("SignIn");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(AppUserSignUpVM appUserSignUpVM)
        {
            if (!ModelState.IsValid) return View(appUserSignUpVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(appUserSignUpVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7000/api/Account/SignUp", stringContent);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) return RedirectToAction("SignIn");

            else if (responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest) ModelState.AddModelError("", "This email or username cannot be used !");

            else ModelState.AddModelError("", "Something went wrong !");

            return RedirectToAction("SignUp");
        }

        public async Task<IActionResult> SignOut()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Account/SignOut");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View("SignIn");
        }
    }
}
