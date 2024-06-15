using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public ProductUpdateDto()
        {
            ImageUpdateDtos = new List<ImageUpdateDto>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
        public string? DetailId { get; set; }
        public IEnumerable<ImageUpdateDto> ImageUpdateDtos { get; set; }
    }
}