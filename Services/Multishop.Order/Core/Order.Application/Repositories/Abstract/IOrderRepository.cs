namespace Order.Application.Repositories.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order.Domain.Entities.Concrete.Order>
    {
    }
}