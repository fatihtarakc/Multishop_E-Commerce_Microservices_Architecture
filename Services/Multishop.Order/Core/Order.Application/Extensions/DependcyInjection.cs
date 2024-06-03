using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Order.Application.Extensions
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}