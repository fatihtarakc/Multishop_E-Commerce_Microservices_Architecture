using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Multishop.Discount.Data.Entities;
using System.Data;

namespace Multishop.Discount.Data.Context
{
    public class DiscountContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DiscountContext(DbContextOptions<DiscountContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("conn");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

        public const string ConnectionName = "conn";
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountContext).Assembly);
        }
    }
}