using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities.Concrete;

namespace Order.Persistance.Configurations
{
    public class DetailConfiguration : BaseEntityConfiguration<Detail>
    {
        public override void Configure(EntityTypeBuilder<Detail> builder)
        {
            base.Configure(builder);
        }
    }
}