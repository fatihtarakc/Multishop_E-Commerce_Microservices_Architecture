using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Multishop.Comment.Data.Context;
using Multishop.Comment.Repositories.Abstract;
using Multishop.Comment.Repositories.Concrete;
using Multishop.Comment.Services.Abstract;
using Multishop.Comment.Services.Concrete;
using System.Reflection;
using System.Text;

namespace Multishop.Comment.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddCommentService(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("conn");
            services.AddDbContext<CommentMicroserviceContext>(options => options.UseSqlServer(connectionString));

            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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

            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<ICommentService, CommentService>();
            return services;
        }
    }
}