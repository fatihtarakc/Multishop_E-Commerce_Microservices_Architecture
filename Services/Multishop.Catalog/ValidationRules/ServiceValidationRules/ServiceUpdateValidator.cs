using FluentValidation;
using Multishop.Catalog.Dtos.ServiceDtos;

namespace Multishop.Catalog.ValidationRules.ServiceValidationRules
{
    public class ServiceUpdateValidator : AbstractValidator<ServiceUpdateDto>
    {
        public ServiceUpdateValidator() 
        {
        }
    }
}