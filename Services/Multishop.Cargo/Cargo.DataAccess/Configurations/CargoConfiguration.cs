using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.DataAccess.Configurations
{
    public class CargoConfiguration : BaseEntityConfiguration<Cargo.Entity.Entities.Concrete.Cargo>
    {
        public override void Configure(EntityTypeBuilder<Entity.Entities.Concrete.Cargo> builder)
        {
            base.Configure(builder);
        }
    }
}