using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Multishop.UI.Handlers;
using Multishop.UI.Options;
using Multishop.UI.Services.Abstract;
using Multishop.UI.Services.Concrete;
using System.Reflection;

namespace Multishop.UI.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddMvcService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.Configure<ClientOptions>
                (configuration.GetSection(ClientOptions.Client));

            services.Configure<Options.RouteOptions>
                (configuration.GetSection(Options.RouteOptions.Route));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.Cookie.Name = "MultishopCookie";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
            });

            var route = configuration.GetSection(Options.RouteOptions.Route).Get<Options.RouteOptions>();

            services.AddTransient<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IAppUserService, AppUserService>(options =>
            {
                options.BaseAddress = new Uri(route.IdentityServer);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            });

            return services;
        }
    }
}