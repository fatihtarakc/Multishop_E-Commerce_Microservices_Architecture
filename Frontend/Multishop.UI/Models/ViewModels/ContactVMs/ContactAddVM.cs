using System.ComponentModel.DataAnnotations;

namespace Multishop.UI.Models.ViewModels.ContactVMs
{
    public class ContactAddVM
    {
        public string NameSurname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}