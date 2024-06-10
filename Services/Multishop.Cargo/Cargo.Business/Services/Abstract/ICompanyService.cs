using Cargo.Dto.CompanyDtos;
using Cargo.Entity.Entities.Concrete;

namespace Cargo.Business.Services.Abstract
{
    public interface ICompanyService : IGenericService<Company, CompanyAddDto, CompanyUpdateDto, CompanyDetailDto, CompanyListDto>
    {
    }
}