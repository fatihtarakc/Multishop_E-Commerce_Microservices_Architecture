using Order.Domain.Entities.Abstract;

namespace Order.Domain.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public Order() 
        {
            Details = new List<Detail>();
        }

        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }

        // Relations
        public IEnumerable<Detail> Details { get; set; }
    }
}