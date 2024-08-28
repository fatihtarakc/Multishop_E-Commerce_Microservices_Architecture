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
            optionsBuilder.UseSqlServer("Server=localhost, 1437; Database=2024MultishopOrderDb; User=sa; Password=Dockermssqldb2024+-!?; Integrated Security=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
