using Cargo.DataAccess.Context;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.Entity.Entities.Concrete;

namespace Cargo.DataAccess.Repositories.Concrete
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CargoMicroserviceContext db) : base(db)
        {
        }
    }
}