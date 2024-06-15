namespace Multishop.UI.Areas.Admin.Models.ViewModels.DetailVMs
{
    public class DetailUpdateVM
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }

        // Relations
        public string ProductId { get; set; }
    }
}