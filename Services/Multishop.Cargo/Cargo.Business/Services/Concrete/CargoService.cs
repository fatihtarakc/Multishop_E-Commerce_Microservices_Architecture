using Cargo.Business.Services.Abstract;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.Dto.CargoDtos;
using Mapster;
using System.Linq.Expressions;

namespace Cargo.Business.Services.Concrete
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository cargoRepository;
        public CargoService(ICargoRepository cargoRepository)
        {
            this.cargoRepository = cargoRepository;
        }

        public async Task<bool> AddAsync(CargoAddDto entityAddDto)
        {
            var cargo = entityAddDto.Adapt<Entity.Entities.Concrete.Cargo>();
            return await cargoRepository.AddAsync(cargo);
        }

        public async Task<bool> DeleteAsync(Guid entityId)
        {
            var cargo = await cargoRepository.GetFirstOrDefaultAsync(cargo => cargo.Id == entityId);
            if (cargo is null) return false;

            return await cargoRepository.DeleteAsync(cargo);
        }

        public async Task<bool> UpdateAsync(CargoUpdateDto entityUpdateDto)
        {
            var cargo = await cargoRepository.GetFirstOrDefaultAsync(cargo => cargo.Id == entityUpdateDto.Id);
            if (cargo is null) return false;

            return await cargoRepository.UpdateAsync(entityUpdateDto.Adapt(cargo));
        }

        public async Task<CargoDetailDto> GetFirstOrDefaultAsync(Expression<Func<Entity.Entities.Concrete.Cargo, bool>> expression)
        {
            return (await cargoRepository.GetFirstOrDefaultAsync(expression)).Adapt<CargoDetailDto>();
        }

        public async Task<IEnumerable<CargoListDto>> GetAllAsync()
        {
            return (await cargoRepository.GetAllAsync()).Adapt<IEnumerable<CargoListDto>>();
        }
    }
}