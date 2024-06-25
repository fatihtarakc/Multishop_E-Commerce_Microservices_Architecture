using FluentValidation;
using Multishop.Catalog.Dtos.ServiceDtos;

namespace Multishop.Catalog.ValidationRules.ServiceValidationRules
{
    public class ServiceAddValidator : AbstractValidator<ServiceAddDto>
    {
        public ServiceAddValidator() 
        {
        }
    }
}