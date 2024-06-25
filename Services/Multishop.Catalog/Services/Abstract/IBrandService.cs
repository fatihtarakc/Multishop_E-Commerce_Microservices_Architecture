using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IBrandService : IGenericService<Brand, BrandDto, BrandAddDto, BrandUpdateDto>
    {
    }
}