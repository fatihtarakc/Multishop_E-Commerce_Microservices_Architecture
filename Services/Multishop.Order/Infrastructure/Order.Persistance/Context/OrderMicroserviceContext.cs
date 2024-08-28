using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities.Concrete;
using System.Reflection;

namespace Order.Persistance.Context
{
    public class OrderMicroserviceContext : DbContext
    {
        public OrderMicroserviceContext() { }
        public OrderMicroserviceContext(DbContextOptions<OrderMicroserviceContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Domain.Entities.Concrete.Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
