using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities.Concrete;

namespace Order.Persistance.Configurations
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);
        }
    }
}