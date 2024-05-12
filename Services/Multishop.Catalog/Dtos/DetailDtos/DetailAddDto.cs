namespace Multishop.Catalog.Dtos.DetailDtos
{
    public class DetailAddDto
    {
        public string Description { get; set; }
        public string Features { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}