using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Dtos.DetailDtos;
using Multishop.Catalog.Dtos.ImageDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Repositories.Concrete;
using Multishop.Catalog.Services.Abstract;
using Multishop.Catalog.Services.Concrete;
using Multishop.Catalog.Settings.Abstract;
using Multishop.Catalog.Settings.Concrete;
using Multishop.Catalog.ValidationRules.CategoryValidationRules;
using Multishop.Catalog.ValidationRules.DetailValidationRules;
using Multishop.Catalog.ValidationRules.ImageValidationRules;
using Multishop.Catalog.ValidationRules.ProductValidationRules;
using System.Reflection;

namespace Multishop.Catalog.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatalogService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddFluentValidation
                (services => { services.RegisterValidatorsFromAssemblyContaining<Program>().DisableDataAnnotationsValidation = false; });

            services.Configure<DbSettings>(configuration.GetSection("MongoDbDatabaseSettings"));

            services.AddTransient<IDbSettings>(serviceProvider =>
            {
                return serviceProvider.GetRequiredService<IOptions<DbSettings>>().Value;
            });

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

            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

            services.AddTransient<IValidator<DetailAddDto>, DetailAddValidator>();
            services.AddTransient<IValidator<DetailUpdateDto>, DetailUpdateValidator>();

            services.AddTransient<IValidator<ImageAddDto>, ImageAddValidator>();
            services.AddTransient<IValidator<ImageUpdateDto>, ImageUpdateValidator>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IDetailRepository, DetailRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}