using System.ComponentModel.DataAnnotations;

namespace Multishop.UI.Models.ViewModels.AppUserVMs
{
    public class AppUserSignInVM
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}