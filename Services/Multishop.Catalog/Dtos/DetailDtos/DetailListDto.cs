namespace Multishop.Catalog.Dtos.DetailDtos
{
    public class DetailListDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}