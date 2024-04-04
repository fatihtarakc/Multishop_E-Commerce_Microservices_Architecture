namespace Multishop.Catalog.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
    }
}