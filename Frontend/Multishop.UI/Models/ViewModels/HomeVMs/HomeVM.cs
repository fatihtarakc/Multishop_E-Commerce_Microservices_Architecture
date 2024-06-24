using Multishop.UI.Models.ViewModels.AdvertisementVMs;
using Multishop.UI.Models.ViewModels.OfferVMs;

namespace Multishop.UI.Models.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public HomeVM() 
        {
            AdvertisementVMs = new List<AdvertisementVM>();
            OfferVMs = new List<OfferVM>();
        }

        public IEnumerable<AdvertisementVM> AdvertisementVMs { get; set; }
        public IEnumerable<OfferVM> OfferVMs { get; set; }
    }
}