using FluentValidation;
using Multishop.Catalog.Dtos.ServiceDtos;

namespace Multishop.Catalog.ValidationRules.ServiceValidationRules
{
    public class ServiceAddValidator : AbstractValidator<ServiceAddDto>
    {
        public ServiceAddValidator() 
        {
            RuleFor(service => service.Name)
                .NotEmpty().WithMessage("Please enter a product name !")
                .MinimumLength(3).WithMessage("Product name can not be less than 3 characters !")
                .MaximumLength(20).WithMessage("Product name can not be greater than 20 characters !");

            RuleFor(service => service.Icon)
                .NotEmpty().WithMessage("Please enter an icon !")
                .MinimumLength(10).WithMessage("Icon can not be less than 10 characters")
                .MaximumLength(250).WithMessage("Icon can not be greater than 250 characters");
        }
    }
}