using Cargo.Entity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.DataAccess.Configurations
{
    public class CompanyConfiguration : BaseEntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Name).HasMaxLength(100);

            builder.HasCheckConstraint("CompanyNameMinLengthConstraint", "Len(Name) > 0");
        }
    }
}