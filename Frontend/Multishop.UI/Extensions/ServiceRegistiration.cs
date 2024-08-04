using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Multishop.UI.Handlers;
using Multishop.UI.Options;
using Multishop.UI.Services.CategoryServices.Abstract;
using Multishop.UI.Services.CategoryServices.Concrete;
using Multishop.UI.Services.IdentityServices.Abstract;
using Multishop.UI.Services.IdentityServices.Concrete;
using System.Reflection;

namespace Multishop.UI.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddMvcService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddAccessTokenManagement();
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.Cookie.Name = "MultishopCookie";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
            });

            services.Configure<ClientOptions>
                (configuration.GetSection(ClientOptions.Client));

            services.Configure<Options.RouteOptions>
                (configuration.GetSection(Options.RouteOptions.Route));

            services.AddTransient<ClientCredentialsTokenHandler>();
            services.AddTransient<ResourceOwnerPasswordTokenHandler>();

            var route = configuration.GetSection(Options.RouteOptions.Route).Get<Options.RouteOptions>();

            services.AddHttpClient<IIdentityService, IdentityService>(options =>
            {
                options.BaseAddress = new Uri(route.IdentityServer);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            return services;
        }
    }
}