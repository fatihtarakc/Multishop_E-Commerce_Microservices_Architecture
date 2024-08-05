namespace Multishop.UI.Models.ViewModels.ImageVMs
{
    public class ImageVM
    {
        public string Id { get; set; }
        public string Url { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}