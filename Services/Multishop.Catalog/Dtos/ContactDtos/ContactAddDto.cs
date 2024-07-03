using System.ComponentModel.DataAnnotations;

namespace Multishop.Catalog.Dtos.ContactDtos
{
    public class ContactAddDto
    {
        public string NameSurname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}