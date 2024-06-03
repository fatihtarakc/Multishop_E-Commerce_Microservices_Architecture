using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Repositories.Abstract;
using Order.Persistance.Context;
using Order.Persistance.Repositories.Concrete;

namespace Order.Persistance.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString(OrderMicroserviceContext.ConnectionName);
            services.AddDbContext<OrderMicroserviceContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IDetailRepository, DetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}