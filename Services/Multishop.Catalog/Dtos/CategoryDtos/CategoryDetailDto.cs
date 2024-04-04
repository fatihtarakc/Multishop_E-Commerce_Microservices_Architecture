using Multishop.Catalog.Data.Entities;

namespace Multishop.Catalog.Dtos.CategoryDtos
{
    public class CategoryDetailDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        // Relations
        public IEnumerable<Product> Products { get; set; }
    }
}