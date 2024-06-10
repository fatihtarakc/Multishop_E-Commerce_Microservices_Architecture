using Cargo.Entity.Entities.Abstract;

namespace Cargo.Entity.Entities.Concrete
{
    public class Cargo : BaseEntity
    {
        public string TrackingNo { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        // Relations
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}