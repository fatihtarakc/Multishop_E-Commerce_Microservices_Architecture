using Cargo.Entity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cargo.DataAccess.Context
{
    public class CargoMicroserviceContext : DbContext
    {
        public CargoMicroserviceContext(DbContextOptions<CargoMicroserviceContext> options) : base(options) { }

        public DbSet<Cargo.Entity.Entities.Concrete.Cargo> Cargos { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Process> Processes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}