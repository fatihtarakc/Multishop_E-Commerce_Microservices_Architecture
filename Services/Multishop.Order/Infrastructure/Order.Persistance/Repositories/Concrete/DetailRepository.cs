using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Concrete;
using Order.Persistance.Context;

namespace Order.Persistance.Repositories.Concrete
{
    public class DetailRepository : GenericRepository<Detail>, IDetailRepository
    {
        public DetailRepository(OrderMicroserviceContext db) : base(db)
        {
        }
    }
}