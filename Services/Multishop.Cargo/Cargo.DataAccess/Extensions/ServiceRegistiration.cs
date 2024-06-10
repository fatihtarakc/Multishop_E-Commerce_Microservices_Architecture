using Cargo.DataAccess.Context;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cargo.DataAccess.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("conn");
            services.AddDbContext<CargoMicroserviceContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IProcessRepository, ProcessRepository>();
            return services;
        }
    }
}