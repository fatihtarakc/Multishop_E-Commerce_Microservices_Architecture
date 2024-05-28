using Microsoft.EntityFrameworkCore;
using Multishop.Discount.Data.Context;
using Multishop.Discount.Repostories.Abstract;
using Multishop.Discount.Repostories.Concrete;
using Multishop.Discount.Services.Abstract;
using Multishop.Discount.Services.Concrete;

namespace Multishop.Discount.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDiscountDataAccess(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString(DiscountContext.ConnectionName);
            services.AddDbContext<DiscountContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddDiscountRepositories(this IServiceCollection services) 
        {
            services.AddTransient<ICouponRepository, CouponRepository>();
            return services;
        }

        public static IServiceCollection AddDiscountServices(this IServiceCollection services) 
        {
            services.AddTransient<ICouponService, CouponService>();
            return services;
        }
    }
}