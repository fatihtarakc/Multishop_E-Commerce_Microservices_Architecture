using System.ComponentModel.DataAnnotations;

namespace Multishop.IdentityServer4.Dtos.AppUserDtos
{
    public class AppUserSignInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}