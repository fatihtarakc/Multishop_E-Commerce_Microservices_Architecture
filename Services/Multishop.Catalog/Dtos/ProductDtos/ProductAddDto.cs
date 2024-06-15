using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Dtos.ProductDtos
{
    public class ProductAddDto
    {
        public ProductAddDto()
        {
            ImageAddDtos = new List<ImageAddDto>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
        public string? DetailId { get; set; }
        public IEnumerable<ImageAddDto> ImageAddDtos { get; set; }
    }
}