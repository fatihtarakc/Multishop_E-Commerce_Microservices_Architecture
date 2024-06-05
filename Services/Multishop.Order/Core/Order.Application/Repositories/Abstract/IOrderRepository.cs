using System.Linq.Expressions;

namespace Order.Application.Repositories.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order.Domain.Entities.Concrete.Order>
    {
        Task<Order.Domain.Entities.Concrete.Order> IncludeDetailsGetFirstOrDefaultAsync(Expression<Func<Order.Domain.Entities.Concrete.Order, bool>> expression);
    }
}