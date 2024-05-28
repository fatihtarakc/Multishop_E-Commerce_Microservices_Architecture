using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multishop.Discount.Data.Entities;

namespace Multishop.Discount.Data.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(b => b.IsActive).HasDefaultValue(true);

            builder.Property(b => b.CreationDate).HasDefaultValue(DateTime.Now);


            builder.HasCheckConstraint("CouponMinRateConstraint", "Rate > 0");
            builder.HasCheckConstraint("CouponMaxRateConstraint", "Rate <= 100");
            builder.HasCheckConstraint("CouponExpirationDateConstraint", "ExpirationDate > GetDate()");
        }
    }
}