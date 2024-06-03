namespace Order.Application.Cqrs.Queries.OrderQueries
{
    public class OrderListQueryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
    }
}