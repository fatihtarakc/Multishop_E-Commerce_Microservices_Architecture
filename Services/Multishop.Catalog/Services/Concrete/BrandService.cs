using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.BrandDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(BrandAddDto entityAddDto)
        {
            var brand = mapper.Map<Brand>(entityAddDto);
            brand.IsActive = false;
            await brandRepository.AddAsync(brand);
        }

        public async Task DeleteAsync(string entityId)
        {
            await brandRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(BrandUpdateDto entityUpdateDto)
        {
            var brand = mapper.Map<Brand>(entityUpdateDto);
            await brandRepository.UpdateAsync(brand);
        }

        public async Task<BrandDto> GetFirstOrDefaultAsync(Expression<Func<Brand, bool>> expression)
        {
            var brand = await brandRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<BrandDto>(brand);
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var brands = await brandRepository.GetAllAsync();
            return mapper.Map<IEnumerable<BrandDto>>(brands);
        }
    }
}