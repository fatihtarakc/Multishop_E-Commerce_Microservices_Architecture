namespace Multishop.Catalog.Dtos.ContactDtos
{
    public class ContactUpdateDto
    {
        public string Id { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
    }
}