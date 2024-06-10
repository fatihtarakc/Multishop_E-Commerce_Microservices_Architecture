using Cargo.Entity.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.DataAccess.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(b => b.CreationDate).HasDefaultValue(DateTime.Now);
        }
    }
}