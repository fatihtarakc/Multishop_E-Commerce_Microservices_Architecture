using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.AppUserVMs;
using Multishop.UI.Services.Abstract;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IAppUserService appUserService;
        public AccountController(IHttpClientFactory httpClientFactory, IAppUserService appUserService)
        {
            this.httpClientFactory = httpClientFactory;
            this.appUserService = appUserService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(AppUserSignInVM appUserSignInVM)
        {
            if (!ModelState.IsValid) return View(appUserSignInVM);

            bool response = await appUserService.SignInAsync(appUserSignInVM);
            if (!response) return View(appUserSignInVM);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(AppUserSignUpVM appUserSignUpVM)
        {
            if (!ModelState.IsValid) return View(appUserSignUpVM);

            var jsonData = JsonConvert.SerializeObject(appUserSignUpVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var client = httpClientFactory.CreateClient();

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

        public async Task<IActionResult> UserGetFirstOrDefaultAsync()
        {
            var user = await appUserService.GetFirstOrDefaultAsync();
            return View(user);
        }
    }
}
