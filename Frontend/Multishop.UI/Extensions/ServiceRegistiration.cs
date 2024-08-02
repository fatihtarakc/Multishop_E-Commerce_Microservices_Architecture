using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Multishop.UI.Handlers;
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

            services.AddTransient<ISignInService, SignInService>();

            var apiGatewayPath = configuration["ApiGateway:Path"];
            var catalogPath = configuration["ServicesPath:Catalog"];
            var identityServerPath = configuration["ServicesPath:IdentityServer"];

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri(apiGatewayPath + "/" + catalogPath);
            });
            services.AddHttpClient<IUserService, UserService>(options =>
            {
                options.BaseAddress = new Uri(apiGatewayPath + "/" + identityServerPath);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.AccessDeniedPath = "/Home/AccessDenied";
                options.LoginPath = "/Account/SignIn";
                options.LogoutPath = "/Account/SignOut";

                options.Cookie.Name = "MultishopCookie";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.HttpOnly = false;
            });

            return services;
        }
    }
}