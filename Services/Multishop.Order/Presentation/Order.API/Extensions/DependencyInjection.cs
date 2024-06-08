using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Order.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = configuration["Token:IdentityServer4Url"];
                options.RequireHttpsMetadata = true;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,

                    ValidAudience = configuration["Token:Audience"]
                };
            });

            return services;
        }
    }
}