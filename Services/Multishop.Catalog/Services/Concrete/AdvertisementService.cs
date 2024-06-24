using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.AdvertisementDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository advertisementRepository;
        private readonly IMapper mapper;
        public AdvertisementService(IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            this.advertisementRepository = advertisementRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(AdvertisementAddDto entityAddDto)
        {
            var advertisement = mapper.Map<Advertisement>(entityAddDto);
            advertisement.IsActive = false;
            await advertisementRepository.AddAsync(advertisement);
        }

        public async Task DeleteAsync(string entityId)
        {
            await advertisementRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(AdvertisementUpdateDto entityUpdateDto)
        {
            var advertisement = mapper.Map<Advertisement>(entityUpdateDto);
            await advertisementRepository.UpdateAsync(advertisement);
        }

        public async Task<AdvertisementDto> GetFirstOrDefaultAsync(Expression<Func<Advertisement, bool>> expression)
        {
            var advertisement = await advertisementRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<AdvertisementDto>(advertisement);
        }

        public async Task<IEnumerable<AdvertisementDto>> GetAllAsync()
        {
            var advertisements = await advertisementRepository.GetAllAsync();
            return mapper.Map<IEnumerable<AdvertisementDto>>(advertisements);
        }
    }
}