using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Concrete;
using Order.Persistance.Context;

namespace Order.Persistance.Repositories.Concrete
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(OrderMicroserviceContext db) : base(db)
        {
        }
    }
}