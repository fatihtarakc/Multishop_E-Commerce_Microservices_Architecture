namespace Order.Domain.Entities.Abstract
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}