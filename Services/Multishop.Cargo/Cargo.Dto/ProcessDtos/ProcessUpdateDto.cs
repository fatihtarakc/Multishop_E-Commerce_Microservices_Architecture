using Cargo.Entity.Enums;

namespace Cargo.Dto.ProcessDtos
{
    public class ProcessUpdateDto
    {
        public Guid Id { get; set; }
        public string TrackingNo { get; set; }
        public CargoStatus CargoStatus { get; set; }
        public string Description { get; set; }
    }
}