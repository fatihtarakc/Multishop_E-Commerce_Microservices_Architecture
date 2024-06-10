using Cargo.Entity.Entities.Abstract;
using Cargo.Entity.Enums;

namespace Cargo.Entity.Entities.Concrete
{
    public class Process : BaseEntity
    {
        public string TrackingNo { get; set; }
        public CargoStatus CargoStatus { get; set; }
        public string Description { get; set; }
    }
}