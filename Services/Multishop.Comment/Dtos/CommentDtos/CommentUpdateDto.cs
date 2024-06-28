using System.ComponentModel.DataAnnotations;

namespace Multishop.Comment.Dtos.CommentDtos
{
    public class CommentUpdateDto
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