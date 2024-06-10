using Cargo.DataAccess.Context;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.Entity.Entities.Concrete;

namespace Cargo.DataAccess.Repositories.Concrete
{
    public class ProcessRepository : GenericRepository<Process>, IProcessRepository
    {
        public ProcessRepository(CargoMicroserviceContext db) : base(db)
        {
        }
    }
}