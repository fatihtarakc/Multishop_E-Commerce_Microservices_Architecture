namespace Multishop.Catalog.Dtos.DetailDtos
{
    public class DetailDetailDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}