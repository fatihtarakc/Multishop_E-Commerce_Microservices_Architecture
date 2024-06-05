using Microsoft.EntityFrameworkCore;
using Order.Application.Repositories.Abstract;
using Order.Persistance.Context;
using System.Linq.Expressions;

namespace Order.Persistance.Repositories.Concrete
{
    public class OrderRepository : GenericRepository<Order.Domain.Entities.Concrete.Order>, IOrderRepository
    {
        private readonly OrderMicroserviceContext db;
        public OrderRepository(OrderMicroserviceContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<Order.Domain.Entities.Concrete.Order> IncludeDetailsGetFirstOrDefaultAsync(Expression<Func<Order.Domain.Entities.Concrete.Order, bool>> expression)
        {
            try
            {
                return await db.Orders.Include(order => order.Details).FirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }
    }
}