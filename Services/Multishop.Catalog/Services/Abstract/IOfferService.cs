using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.OfferDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IOfferService : IGenericService<Offer, OfferDto, OfferAddDto, OfferUpdateDto>
    {
    }
}