using FluentValidation;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.ValidationRules.ImageValidationRules
{
    public class ImageUpdateValidator : AbstractValidator<ImageUpdateDto>
    {
        public ImageUpdateValidator() 
        {
            RuleFor(image => image.Id)
               .NotEmpty().WithMessage("Please enter a Id !");

            RuleFor(image => image.Url)
                .NotEmpty().WithMessage("Please enter an url !")
                .MinimumLength(10).WithMessage("Url can not be less than 10 characters !")
                .MaximumLength(250).WithMessage("Url can not be greater than 250 characters !");

            RuleFor(image => image.ProductId)
               .NotEmpty().WithMessage("Please enter a productId !");
        }
    }
}