using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.AdvertisementDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IAdvertisementService : IGenericService<Advertisement, AdvertisementDto, AdvertisementAddDto, AdvertisementUpdateDto>
    {
    }
}