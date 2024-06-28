namespace Multishop.Comment.Data.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}