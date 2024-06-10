using Cargo.DataAccess.Context;
using Cargo.DataAccess.Repositories.Abstract;

namespace Cargo.DataAccess.Repositories.Concrete
{
    public class CargoRepository : GenericRepository<Cargo.Entity.Entities.Concrete.Cargo>, ICargoRepository
    {
        public CargoRepository(CargoMicroserviceContext db) : base(db)
        {
        }
    }
}