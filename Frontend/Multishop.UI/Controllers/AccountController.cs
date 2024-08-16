using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.AppUserVMs;
using Multishop.UI.Services.AppUserServices.Abstract;
using Multishop.UI.Services.IdentityServices.Abstract;

namespace Multishop.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService appUserService;
        private readonly IIdentityService identityService;
        public AccountController(IAppUserService appUserService, IIdentityService identityService)
        {
            this.appUserService = appUserService;
            this.identityService = identityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(AppUserSignInVM appUserSignInVM)
        {
            if (!ModelState.IsValid) return View(appUserSignInVM);

            bool response = await identityService.SignInWithTokenAsync(appUserSignInVM);
            if (!response) return View(appUserSignInVM);

            //return RedirectToAction("UserGetFirstOrDefault", "Account", new { area = "" });
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

            var responseMessage = await identityService.SignUpAsync(appUserSignUpVM);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) return RedirectToAction("SignIn");

            else if (responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest) ModelState.AddModelError("", "This email or username cannot be used !");

            else ModelState.AddModelError("", "Something went wrong !");

            return RedirectToAction("SignUp");
        }

        public async Task<IActionResult> SignOut()
        {
            bool response = await identityService.SignOutAsync();
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View("SignIn");
        }

        public async Task<IActionResult> UserGetFirstOrDefault()
        {
            var user = await appUserService.GetFirstOrDefaultAsync();
            return View(user);
        }
    }
}