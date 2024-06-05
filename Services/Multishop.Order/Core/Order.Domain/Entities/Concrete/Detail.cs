using Order.Domain.Entities.Abstract;

namespace Order.Domain.Entities.Concrete
{
    public class Detail : BaseEntity
    {
        // Product entity has been located MongoDb database.
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }

        // Relations
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}