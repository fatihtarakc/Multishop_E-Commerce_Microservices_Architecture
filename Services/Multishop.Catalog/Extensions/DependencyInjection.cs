using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Multishop.Catalog.Dtos.AdvertisementDtos;
using Multishop.Catalog.Dtos.BrandDtos;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Dtos.ContactDtos;
using Multishop.Catalog.Dtos.DetailDtos;
using Multishop.Catalog.Dtos.ImageDtos;
using Multishop.Catalog.Dtos.OfferDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Dtos.ServiceDtos;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Repositories.Concrete;
using Multishop.Catalog.Services.Abstract;
using Multishop.Catalog.Services.Concrete;
using Multishop.Catalog.Settings.Abstract;
using Multishop.Catalog.Settings.Concrete;
using Multishop.Catalog.ValidationRules.AdvertisementValidationRules;
using Multishop.Catalog.ValidationRules.BrandValidationRules;
using Multishop.Catalog.ValidationRules.CategoryValidationRules;
using Multishop.Catalog.ValidationRules.ContactValidationRules;
using Multishop.Catalog.ValidationRules.DetailValidationRules;
using Multishop.Catalog.ValidationRules.ImageValidationRules;
using Multishop.Catalog.ValidationRules.OfferValidationRules;
using Multishop.Catalog.ValidationRules.ProductValidationRules;
using Multishop.Catalog.ValidationRules.ServiceValidationRules;
using System.Reflection;
using System.Text;

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

                    //ValidateIssuer = true,
                    //ValidIssuer = configuration["Token:Issuer"],
                    //ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:IssuerSigningKey"])),
                    //ValidateLifetime = true
                };
            });

            services.AddTransient<IValidator<AdvertisementAddDto>, AdvertisementAddValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateValidator>();

            services.AddTransient<IValidator<BrandAddDto>, BrandAddValidator>();
            services.AddTransient<IValidator<BrandUpdateDto>, BrandUpdateValidator>();

            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

            services.AddTransient<IValidator<ContactAddDto>, ContactAddValidator>();
            services.AddTransient<IValidator<ContactUpdateDto>, ContactUpdateValidator>();

            services.AddTransient<IValidator<DetailAddDto>, DetailAddValidator>();
            services.AddTransient<IValidator<DetailUpdateDto>, DetailUpdateValidator>();

            services.AddTransient<IValidator<ImageAddDto>, ImageAddValidator>();
            services.AddTransient<IValidator<ImageUpdateDto>, ImageUpdateValidator>();
            
            services.AddTransient<IValidator<OfferAddDto>, OfferAddValidator>();
            services.AddTransient<IValidator<OfferUpdateDto>, OfferUpdateValidator>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();
            
            services.AddTransient<IValidator<ServiceAddDto>, ServiceAddValidator>();
            services.AddTransient<IValidator<ServiceUpdateDto>, ServiceUpdateValidator>();

            services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IDetailRepository, DetailRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();

            services.AddTransient<IAdvertisementService, AdvertisementService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IServiceService, ServiceService>();

            return services;
        }
    }
}