using FluentValidation;
using Multishop.UI.Areas.Admin.Models.ViewModels.BrandVMs;

namespace Multishop.UI.ValidationRules.BrandValidationRules
{
    public class BrandUpdateValidator : AbstractValidator<BrandUpdateVM>
    {
        public BrandUpdateValidator() 
        {
            RuleFor(brand => brand.Id)
               .NotEmpty().WithMessage("Please enter an Id !");

            RuleFor(brand => brand.Name)
                .NotEmpty().WithMessage("Please enter a brand name !")
                .MinimumLength(1).WithMessage("Name can not be less than 1 characters !")
                .MaximumLength(50).WithMessage("Name can not be greater than 50 characters !");

            RuleFor(brand => brand.ImageUrl)
                .NotEmpty().WithMessage("Please enter a image url !")
                .MinimumLength(3).WithMessage("Image url can not be less than 3 characters !")
                .MaximumLength(250).WithMessage("Image url can not be greater than 250 characters !");

            RuleFor(brand => brand.IsActive)
               .NotEmpty().WithMessage("Brand active value can not be null or empty !");
        }
    }
}