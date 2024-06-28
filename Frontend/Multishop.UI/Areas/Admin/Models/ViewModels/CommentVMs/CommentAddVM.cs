using System.ComponentModel.DataAnnotations;

namespace Multishop.UI.Areas.Admin.Models.ViewModels.CommentVMs
{
    public class CommentAddVM
    {
        public string NameSurname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}