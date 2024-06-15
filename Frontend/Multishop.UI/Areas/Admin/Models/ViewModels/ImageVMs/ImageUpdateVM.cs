namespace Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs
{
    public class ImageUpdateVM
    {
        public string Id { get; set; }
        public string Url { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}