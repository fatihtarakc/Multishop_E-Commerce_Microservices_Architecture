using Multishop.UI.Services.BasketServices.Abstract;

namespace Multishop.UI.Services.BasketServices.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient httpClient;
        public BasketService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


    }
}