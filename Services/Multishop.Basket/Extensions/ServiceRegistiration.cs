using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Multishop.Basket.Services.BasketServices;
using Multishop.Basket.Services.IdentityServices;
using Multishop.Basket.Services.RedisServices;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace Multishop.Basket.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = configuration["Token:IdentityServer4Url"];
                options.RequireHttpsMetadata = true;

                options.TokenValidationParameters = new()
                {
                    ValidateAudience = true,

                    ValidAudience = configuration["Token:Audience"]

                    //ValidateIssuer = true,
                    //ValidIssuer = configuration["Token:Issuer"],
                    //ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:IssuerSigningKey"])),
                    //ValidateLifetime = true
                };
            });
            
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.Configure<Options.RedisOptions>
                (configuration.GetSection(Options.RedisOptions.Redis));

            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IRedisService, RedisService>(serviceProvider => 
            {
                var redisOptions = serviceProvider.GetRequiredService<IOptions<Options.RedisOptions>>().Value;
                var redis = new RedisService(redisOptions.Host, redisOptions.Port);
                redis.Connect();
                return redis;
            });

            return services;
        }
    }
}