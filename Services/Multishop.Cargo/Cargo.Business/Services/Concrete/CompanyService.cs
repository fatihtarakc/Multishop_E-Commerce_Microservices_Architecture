using Cargo.Business.Services.Abstract;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.Dto.CompanyDtos;
using Cargo.Entity.Entities.Concrete;
using Mapster;
using System.Linq.Expressions;

namespace Cargo.Business.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<bool> AddAsync(CompanyAddDto entityAddDto)
        {
            var company = entityAddDto.Adapt<Company>();
            return await companyRepository.AddAsync(company);
        }

        public async Task<bool> DeleteAsync(Guid entityId)
        {
            var company = await companyRepository.GetFirstOrDefaultAsync(company => company.Id == entityId);
            if (company is null) return false;

            return await companyRepository.DeleteAsync(company);
        }

        public async Task<bool> UpdateAsync(CompanyUpdateDto entityUpdateDto)
        {
            var company = await companyRepository.GetFirstOrDefaultAsync(company => company.Id == entityUpdateDto.Id);
            if (company is null) return false;

            return await companyRepository.UpdateAsync(entityUpdateDto.Adapt(company));
        }

        public async Task<CompanyDetailDto> GetFirstOrDefaultAsync(Expression<Func<Company, bool>> expression)
        {
            return (await companyRepository.GetFirstOrDefaultAsync(expression)).Adapt<CompanyDetailDto>();
        }

        public async Task<IEnumerable<CompanyListDto>> GetAllAsync()
        {
            return (await companyRepository.GetAllAsync()).Adapt<IEnumerable<CompanyListDto>>();
        }
    }
}