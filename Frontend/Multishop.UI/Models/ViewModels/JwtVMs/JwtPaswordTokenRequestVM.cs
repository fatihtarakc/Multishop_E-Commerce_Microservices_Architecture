using IdentityModel.Client;

namespace Multishop.UI.Models.ViewModels.JwtVMs
{
    public class JwtPaswordTokenRequestVM : PasswordTokenRequest
    {
        public string Email { get; set; }
    }
}