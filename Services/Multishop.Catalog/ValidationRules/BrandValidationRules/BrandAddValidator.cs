using FluentValidation;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.ValidationRules.BrandValidationRules
{
    public class BrandAddValidator : AbstractValidator<BrandAddDto>
    {
        public BrandAddValidator() 
        {
            RuleFor(brand => brand.Name)
                .NotEmpty().WithMessage("Please enter a brand name !")
                .MinimumLength(1).WithMessage("Name can not be less than 1 characters !")
                .MaximumLength(50).WithMessage("Name can not be greater than 50 characters !");

            RuleFor(brand => brand.ImageUrl)
                .NotEmpty().WithMessage("Please enter a image url !")
                .MinimumLength(3).WithMessage("Image url can not be less than 3 characters !")
                .MaximumLength(250).WithMessage("Image url can not be greater than 250 characters !");
        }
    }
}