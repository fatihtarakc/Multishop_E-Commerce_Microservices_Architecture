using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer4.Data.Entities;
using Multishop.IdentityServer4.Dtos.AppUserDtos;
using Multishop.IdentityServer4.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Multishop.IdentityServer4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(AppUserSignInDto appUserSignInDto)
        {
            if (!ModelState.IsValid) return BadRequest("Email or password must not be null !");

            var appUserByEmail = await userManager.FindByEmailAsync(appUserSignInDto.Email);
            if (appUserByEmail is null) return BadRequest("Email or password is incorrect !");

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(appUserByEmail, appUserSignInDto.Password, appUserSignInDto.RememberMe, false);
            if (!signInResult.Succeeded) return BadRequest("Email or password is incorrect !");

            var appUserDto = new AppUserDto { Id = appUserByEmail.Id, Username = appUserByEmail.UserName, Role = (await userManager.GetRolesAsync(appUserByEmail)).FirstOrDefault() };

            var token = tokenService.Generator(appUserDto);
            return Ok(token);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(AppUserSignUpDto appUserSignUpDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var appUserByEmail = await userManager.FindByEmailAsync(appUserSignUpDto.Email);
            var appUserByUsername = await userManager.FindByNameAsync(appUserSignUpDto.Username);
            if (!(appUserByEmail is null)) return BadRequest("This email address cannot be used !");
            if (!(appUserByUsername is null)) return BadRequest("This email address cannot be used !");

            var appUser = new AppUser()
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

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}