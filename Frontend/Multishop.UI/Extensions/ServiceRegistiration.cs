using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Multishop.UI.Services.Abstract;
using Multishop.UI.Services.Concrete;
using System.Reflection;

namespace Multishop.UI.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddMvcService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<ISignInService, SignInService>();

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

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}