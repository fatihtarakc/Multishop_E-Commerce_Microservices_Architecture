namespace Multishop.Catalog.Dtos.ImageDtos
{
    public class ImageListDto
    {
        public string Id { get; set; }
        public string Url { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}