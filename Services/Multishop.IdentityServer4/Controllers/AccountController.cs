using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer4.Dtos;
using Multishop.IdentityServer4.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Multishop.IdentityServer4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(AppUserSignUpDto appUserSignUpDto)
        {
            var appUser = new ApplicationUser()
            {
                Name = appUserSignUpDto.Name,
                Surname = appUserSignUpDto.Surname,
                UserName = appUserSignUpDto.Username,
                Email = appUserSignUpDto.Email
            };
            appUser.PasswordHash = userManager.PasswordHasher.HashPassword(appUser, appUserSignUpDto.Password);
            var identityResult = await userManager.CreateAsync(appUser);
            if (!identityResult.Succeeded) return BadRequest("Sign up process is unsuccess !");

            return Ok("Sign up process is success !");
        }
    }
}