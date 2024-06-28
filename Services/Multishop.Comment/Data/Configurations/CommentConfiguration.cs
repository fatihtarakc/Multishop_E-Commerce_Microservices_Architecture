using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Multishop.Comment.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Data.Entities.Comment>
    {
        public void Configure(EntityTypeBuilder<Entities.Comment> builder)
        {
            builder.Property(b => b.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(b => b.NameSurname).HasMaxLength(50);
            builder.Property(b => b.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(b => b.Review).HasMaxLength(250);
            builder.Property(b => b.Rating).HasColumnType("tinyint").HasDefaultValue(0);
            builder.Property(b => b.IsActive).HasDefaultValue(true);
            builder.Property(b => b.CreationDate).HasDefaultValue(DateTime.Now);
            builder.Property(b => b.ProductId).HasColumnType("varchar").HasMaxLength(50);

            builder.HasCheckConstraint("CommentNameSurnameMinLengthConstraint", "Len(NameSurname) >= 5");
            builder.HasCheckConstraint("CommentEmailMinLengthConstraint", "Len(Email) >= 5");
            builder.HasCheckConstraint("CommentReviewMinLengthConstraint", "Len(Review) >= 10");
            builder.HasCheckConstraint("CommentRatingMinConstraint", "Rating >= 0");
            builder.HasCheckConstraint("CommentRatingMaxConstraint", "Rating <= 5");
        }
    }
}