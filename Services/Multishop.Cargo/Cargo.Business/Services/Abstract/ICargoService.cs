using Cargo.Dto.CargoDtos;

namespace Cargo.Business.Services.Abstract
{
    public interface ICargoService : IGenericService<Entity.Entities.Concrete.Cargo, CargoAddDto, CargoUpdateDto, CargoDetailDto, CargoListDto>
    {
    }
}