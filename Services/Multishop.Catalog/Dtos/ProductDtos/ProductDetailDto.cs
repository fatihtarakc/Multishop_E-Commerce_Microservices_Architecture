using Multishop.Catalog.Data.Entities;

namespace Multishop.Catalog.Dtos.ProductDtos
{
    public class ProductDetailDto
    {
        public ProductDetailDto()
        {
            Images = new List<Image>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
        public string DetailId { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}