using Order.Application.Repositories.Abstract;
using Order.Persistance.Context;

namespace Order.Persistance.Repositories.Concrete
{
    public class OrderRepository : GenericRepository<Order.Domain.Entities.Concrete.Order>, IOrderRepository
    {
        public OrderRepository(OrderMicroserviceContext db) : base(db)
        {
        }
    }
}