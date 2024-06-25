using Multishop.UI.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Models.ViewModels.BrandVMs;
using Multishop.UI.Models.ViewModels.OfferVMs;
using Multishop.UI.Models.ViewModels.ServiceVMs;

namespace Multishop.UI.Models.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public HomeVM() 
        {
            AdvertisementVMs = new List<AdvertisementVM>();
            BrandVMs = new List<BrandVM>();
            OfferVMs = new List<OfferVM>();
            ServiceVMs = new List<ServiceVM>();
        }

        public IEnumerable<AdvertisementVM> AdvertisementVMs { get; set; }
        public IEnumerable<BrandVM> BrandVMs { get; set; }
        public IEnumerable<OfferVM> OfferVMs { get; set; }
        public IEnumerable<ServiceVM> ServiceVMs { get; set; }
    }
}