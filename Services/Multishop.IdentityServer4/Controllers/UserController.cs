using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Multishop.IdentityServer4.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Multishop.IdentityServer4.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("GetFirstOrDefault")]
        public async Task<IActionResult> GetFirstOrDefault()
        {
            var userClaim = User.Claims.FirstOrDefault(user => user.Type == JwtRegisteredClaimNames.Sub);
            var user = await userManager.FindByIdAsync(userClaim.Value);
            return Ok(new { Id = user.Id, Name = user.Name, Surname = user.Surname, Username = user.UserName, Email = user.Email });
        }
    }
}