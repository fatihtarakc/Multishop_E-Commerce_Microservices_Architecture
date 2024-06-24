using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.OfferDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;
        public OfferService(IOfferRepository offerRepository, IMapper mapper)
        {
            this.offerRepository = offerRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(OfferAddDto entityAddDto)
        {
            var offer = mapper.Map<Offer>(entityAddDto);
            offer.IsActive = false;
            await offerRepository.AddAsync(offer);
        }

        public async Task DeleteAsync(string entityId)
        {
            await offerRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(OfferUpdateDto entityUpdateDto)
        {
            var offer = mapper.Map<Offer>(entityUpdateDto);
            await offerRepository.UpdateAsync(offer);
        }

        public async Task<OfferDto> GetFirstOrDefaultAsync(Expression<Func<Offer, bool>> expression)
        {
            var offer = await offerRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<OfferDto>(offer);
        }

        public async Task<IEnumerable<OfferDto>> GetAllAsync()
        {
            var offers = await offerRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OfferDto>>(offers);
        }
    }
}