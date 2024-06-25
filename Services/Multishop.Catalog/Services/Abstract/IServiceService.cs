using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ServiceDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IServiceService : IGenericService<Service, ServiceDto, ServiceAddDto, ServiceUpdateDto>
    {
    }
}