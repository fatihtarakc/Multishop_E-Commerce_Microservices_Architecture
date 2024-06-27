using FluentValidation;
using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;

namespace Multishop.UI.ValidationRules.ImageValidationRules
{
    public class ImageAddValidator : AbstractValidator<ImageAddVM>
    {
        public ImageAddValidator() 
        {
            RuleFor(image => image.Url)
                .NotEmpty().WithMessage("Please enter an url !")
                .MinimumLength(10).WithMessage("Url can not be less than 10 characters")
                .MaximumLength(250).WithMessage("Url can not be greater than 250 characters");

            RuleFor(image => image.ProductId)
               .NotEmpty().WithMessage("Please enter a productId !");
        }
    }
}