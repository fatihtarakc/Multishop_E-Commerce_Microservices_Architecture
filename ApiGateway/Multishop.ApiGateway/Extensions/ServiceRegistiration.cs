using Ocelot.DependencyInjection;

namespace Multishop.ApiGateway.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddApiGatewayService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAuthentication().AddJwtBearer(configuration["Token:AuthenticationProviderKey"], options =>
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

            configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
            services.AddOcelot(configuration);

            return services;
        }
    }
}