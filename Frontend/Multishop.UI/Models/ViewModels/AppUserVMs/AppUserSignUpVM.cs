using System.ComponentModel.DataAnnotations;

namespace Multishop.UI.Models.ViewModels.AppUserVMs
{
    public class AppUserSignUpVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}