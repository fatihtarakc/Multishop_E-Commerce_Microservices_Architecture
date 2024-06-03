using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities.Abstract;

namespace Order.Persistance.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(b => b.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(b => b.CreationDate).HasDefaultValue(DateTime.Now);
        }
    }
}