using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Multishop.Discount.Data.Context;
using Multishop.Discount.Repostories.Abstract;
using Multishop.Discount.Repostories.Concrete;
using Multishop.Discount.Services.Abstract;
using Multishop.Discount.Services.Concrete;
using System.Text;

namespace Multishop.Discount.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDiscountDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DiscountContext.ConnectionName);
            services.AddDbContext<DiscountContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddDiscountRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICouponRepository, CouponRepository>();
            return services;
        }

        public static IServiceCollection AddDiscountServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICouponService, CouponService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = configuration["Token:IdentityServer4Url"];
                options.RequireHttpsMetadata = true;

                options.TokenValidationParameters = new TokenValidationParameters()
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
            return services;
        }
    }
}