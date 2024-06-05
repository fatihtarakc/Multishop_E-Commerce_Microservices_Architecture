using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Application.Extensions
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
            services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(DependcyInjection).Assembly));
            return services;
        }
    }
}