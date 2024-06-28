using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Multishop.Comment.Data.Context
{
    public class CommentMicroserviceContext : DbContext
    {
        public CommentMicroserviceContext(DbContextOptions<CommentMicroserviceContext> options) : base(options) { }

        public DbSet<Data.Entities.Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}