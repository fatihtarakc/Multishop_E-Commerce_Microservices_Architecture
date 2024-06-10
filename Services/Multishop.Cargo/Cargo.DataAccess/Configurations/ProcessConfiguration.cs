using Cargo.Entity.Entities.Concrete;
using Cargo.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.DataAccess.Configurations
{
    public class ProcessConfiguration : BaseEntityConfiguration<Process>
    {
        public override void Configure(EntityTypeBuilder<Process> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.CargoStatus).HasDefaultValue(CargoStatus.Given);
            builder.Property(b => b.Description).HasMaxLength(250);
            builder.HasCheckConstraint("ProcessDescriptionMinLengthConstraint", "Len(Description) > 0");
        }
    }
}