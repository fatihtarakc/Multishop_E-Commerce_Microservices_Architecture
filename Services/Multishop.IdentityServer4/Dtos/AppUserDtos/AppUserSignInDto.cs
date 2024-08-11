namespace Multishop.IdentityServer4.Dtos.AppUserDtos
{
    public class AppUserSignInDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}