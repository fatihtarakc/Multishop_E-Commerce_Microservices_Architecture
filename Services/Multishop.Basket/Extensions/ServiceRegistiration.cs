using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Multishop.Basket.Services.BasketServices;
using Multishop.Basket.Services.LoginServices;
using Multishop.Basket.Settings;
using System.IdentityModel.Tokens.Jwt;

namespace Multishop.Basket.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidation
                (services => services.RegisterValidatorsFromAssemblyContaining<Program>().DisableDataAnnotationsValidation = false);

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = configuration["Token:IdentityServer4Url"];
                options.RequireHttpsMetadata = true;

                options.TokenValidationParameters = new()
                {
                    ValidateAudience = true,

                    ValidAudience = configuration["Token:Audience"]
                };
            });

            services.AddHttpContextAccessor();

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ILoginService, LoginService>();

            services.Configure<RedisDbSettings>(configuration.GetSection("Redis"));

            services.AddSingleton<RedisService>(serviceProvider => 
            {
                var redisSettings = serviceProvider.GetRequiredService<IOptions<RedisDbSettings>>().Value;
                var redis = new RedisService(redisSettings.Host, redisSettings.Port);
                redis.Connect();
                return redis;
            });
            return services;
        }
    }
}