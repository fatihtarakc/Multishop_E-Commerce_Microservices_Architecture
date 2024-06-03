using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities.Concrete;
using System.Reflection;

namespace Order.Persistance.Context
{
    public class OrderMicroserviceContext : DbContext
    {
        public const string ConnectionName = "conn";
        public OrderMicroserviceContext(DbContextOptions<OrderMicroserviceContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Order.Domain.Entities.Concrete.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
