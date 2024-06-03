using Order.Domain.Entities.Concrete;

namespace Order.Application.Cqrs.Queries.OrderQueries
{
    public class OrderDetailQueryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }

        // Relations
        public IEnumerable<Detail> Details { get; set; }
    }
}