using System.ComponentModel.DataAnnotations;

namespace Multishop.UI.Models.ViewModels.CommentVMs
{
    public class CommentUpdateVM
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}