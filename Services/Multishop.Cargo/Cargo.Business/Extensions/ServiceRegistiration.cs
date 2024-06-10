using Cargo.Business.Services.Abstract;
using Cargo.Business.Services.Concrete;
using Cargo.Business.ValidationRules.CargoValidationRules;
using Cargo.Business.ValidationRules.CompanyValidationRules;
using Cargo.Business.ValidationRules.ProcessValidationRules;
using Cargo.Dto.CargoDtos;
using Cargo.Dto.CompanyDtos;
using Cargo.Dto.ProcessDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cargo.Business.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services) 
        {
            services.AddTransient<IValidator<CargoAddDto>, CargoAddValidator>(); 
            services.AddTransient<IValidator<CargoUpdateDto>, CargoUpdateValidator>();


            services.AddTransient<IValidator<CompanyAddDto>, CompanyAddValidator>();
            services.AddTransient<IValidator<CompanyUpdateDto>, CompanyUpdateValidator>();
            
            services.AddTransient<IValidator<ProcessAddDto>, ProcessAddValidator>();
            services.AddTransient<IValidator<ProcessUpdateDto>, ProcessUpdateValidator>();
            
            services.AddTransient<ICargoService, CargoService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProcessService, ProcessService>();

            return services;
        }
    }
}