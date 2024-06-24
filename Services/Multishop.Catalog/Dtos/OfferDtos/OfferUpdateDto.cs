namespace Multishop.Catalog.Dtos.OfferDtos
{
    public class OfferUpdateDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}