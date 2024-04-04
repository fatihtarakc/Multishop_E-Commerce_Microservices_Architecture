namespace Multishop.Catalog.Dtos.ImageDtos
{
    public class ImageAddDto
    {
        public string Url { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}