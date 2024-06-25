using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ServiceDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;
        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(ServiceAddDto entityAddDto)
        {
            var service = mapper.Map<Service>(entityAddDto);
            service.IsActive = false;
            await serviceRepository.AddAsync(service);
        }

        public async Task DeleteAsync(string entityId)
        {
            await serviceRepository.DeleteAsync(entityId);
        }

        public async Task UpdateAsync(ServiceUpdateDto entityUpdateDto)
        {
            var service = mapper.Map<Service>(entityUpdateDto);
            await serviceRepository.UpdateAsync(service);
        }

        public async Task<ServiceDto> GetFirstOrDefaultAsync(Expression<Func<Service, bool>> expression)
        {
            var service = await serviceRepository.GetFirstOrDefaultAsync(expression);
            return mapper.Map<ServiceDto>(service);
        }

        public async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {
            var services = await serviceRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ServiceDto>>(services);
        }
    }
}