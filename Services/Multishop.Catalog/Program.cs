using FluentValidation;
using FluentValidation.AspNetCore;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddFluentValidation
    (b => { b.RegisterValidatorsFromAssemblyContaining<Program>().DisableDataAnnotationsValidation = true; });

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("MongodbDatabaseSettings"));

builder.Services.AddTransient<IDbSettings>(serviceProvider =>
{
    return serviceProvider.GetRequiredService<IOptions<DbSettings>>().Value;
});

builder.Services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
builder.Services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

builder.Services.AddTransient<IValidator<DetailAddDto>, DetailAddValidator>();
builder.Services.AddTransient<IValidator<DetailUpdateDto>, DetailUpdateValidator>();

builder.Services.AddTransient<IValidator<ImageAddDto>, ImageAddValidator>();
builder.Services.AddTransient<IValidator<ImageUpdateDto>, ImageUpdateValidator>();

builder.Services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
builder.Services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IDetailRepository, DetailRepository>();
builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IDetailService, DetailService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
