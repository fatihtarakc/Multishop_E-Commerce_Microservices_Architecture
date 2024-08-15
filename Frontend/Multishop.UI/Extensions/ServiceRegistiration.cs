using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Multishop.UI.Handlers;
using Multishop.UI.Services.AdvertisementServices.Abstract;
using Multishop.UI.Services.AdvertisementServices.Concrete;
using Multishop.UI.Services.AppUserServices.Abstract;
using Multishop.UI.Services.AppUserServices.Concrete;
using Multishop.UI.Services.BrandServices.Abstract;
using Multishop.UI.Services.BrandServices.Concrete;
using Multishop.UI.Services.CategoryServices.Abstract;
using Multishop.UI.Services.CategoryServices.Concrete;
using Multishop.UI.Services.CommentServices.Abstract;
using Multishop.UI.Services.CommentServices.Concrete;
using Multishop.UI.Services.ContactServices.Abstract;
using Multishop.UI.Services.ContactServices.Concrete;
using Multishop.UI.Services.DetailServices.Abstract;
using Multishop.UI.Services.DetailServices.Concrete;
using Multishop.UI.Services.IdentityServices.Abstract;
using Multishop.UI.Services.IdentityServices.Concrete;
using Multishop.UI.Services.ImageServices.Abstract;
using Multishop.UI.Services.ImageServices.Concrete;
using Multishop.UI.Services.OfferServices.Abstract;
using Multishop.UI.Services.OfferServices.Concrete;
using Multishop.UI.Services.ProductServices.Abstract;
using Multishop.UI.Services.ProductServices.Concrete;
using Multishop.UI.Services.ServiceServices.Abstract;
using Multishop.UI.Services.ServiceServices.Concrete;
using System.Reflection;

namespace Multishop.UI.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddMvcService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.Cookie.Name = "MultishopCookie";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
            });

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddAccessTokenManagement();
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.Configure<Options.ClientOptions>
                (configuration.GetSection(Options.ClientOptions.Client));

            services.Configure<Options.RouteOptions>
                (configuration.GetSection(Options.RouteOptions.Route));

            services.AddTransient<ClientCredentialsTokenHandler>();
            services.AddTransient<ResourceOwnerPasswordTokenHandler>();

            var route = configuration.GetSection(Options.RouteOptions.Route).Get<Options.RouteOptions>();

            services.AddHttpClient<IIdentityService, IdentityService>();

            services.AddHttpClient<IAdvertisementService, AdvertisementService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IAppUserService, AppUserService>(options =>
            {
                options.BaseAddress = new Uri(route.IdentityServer);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IBrandService, BrandService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<ICommentService, CommentService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Comment);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IContactService, ContactService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IDetailService, DetailService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IImageService, ImageService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IOfferService, OfferService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IProductService, ProductService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            services.AddHttpClient<IServiceService, ServiceService>(options =>
            {
                options.BaseAddress = new Uri(route.ApiGateway + "/" + route.Catalog);
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            return services;
        }
    }
}