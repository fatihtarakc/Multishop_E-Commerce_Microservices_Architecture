using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer4.Data.Entities;
using Multishop.IdentityServer4.Dtos.AppUserDtos;
using System.Threading.Tasks;

namespace Multishop.IdentityServer4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(AppUserSignUpDto appUserSignUpDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var appUserByEmail = await userManager.FindByEmailAsync(appUserSignUpDto.Email);
            if (!(appUserByEmail is null)) return BadRequest("This email address cannot be used !");
            var appUserByUsername = await userManager.FindByNameAsync(appUserSignUpDto.Username);
            if (!(appUserByUsername is null)) return BadRequest("This username cannot be used !");

            var appUser = new AppUser()
            {
                Name = appUserSignUpDto.Name,
                Surname = appUserSignUpDto.Surname,
                UserName = appUserSignUpDto.Username,
                Email = appUserSignUpDto.Email
            };
            appUser.PasswordHash = userManager.PasswordHasher.HashPassword(appUser, appUserSignUpDto.Password);
            var identityResult = await userManager.CreateAsync(appUser);
            if (!identityResult.Succeeded) return BadRequest("Sign up is failed !");

            return Ok("Sign up is successful !");
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}