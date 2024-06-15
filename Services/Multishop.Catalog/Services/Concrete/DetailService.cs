using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class DetailService : IDetailService
    {
        private readonly IDetailRepository detailRepository;
        private readonly IMapper mapper;
        public DetailService(IDetailRepository detailRepository, IMapper mapper)
        {
            this.detailRepository = detailRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(DetailAddDto entityAddDto)
        {
            var detail = mapper.Map<Detail>(entityAddDto);
            await detailRepository.AddAsync(detail);
        }

        public async Task DeleteAsync(string entityId)
        {
            await detailRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(DetailUpdateDto entityUpdateDto)
        {
            var detail = mapper.Map<Detail>(entityUpdateDto);
            await detailRepository.UpdateAsync(detail);
        }

        public async Task<DetailDto> GetFirstOrDefaultAsync(Expression<Func<Detail, bool>> expression)
        {
            var detail = await detailRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<DetailDto>(detail);
        }

        public async Task<IEnumerable<DetailDto>> GetAllAsync()
        {
            var details = await detailRepository.GetAllAsync();
            return mapper.Map<IEnumerable<DetailDto>>(details);
        }
    }
}