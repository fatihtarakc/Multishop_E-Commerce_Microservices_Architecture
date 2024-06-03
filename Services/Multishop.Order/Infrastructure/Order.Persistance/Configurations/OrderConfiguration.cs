using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistance.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order.Domain.Entities.Concrete.Order>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Concrete.Order> builder)
        {
            base.Configure(builder);
        }
    }
}