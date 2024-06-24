using FluentValidation;
using Multishop.Catalog.Dtos.AdvertisementDtos;

namespace Multishop.Catalog.ValidationRules.AdvertisementValidationRules
{
    public class AdvertisementAddValidator : AbstractValidator<AdvertisementAddDto>
    {
        public AdvertisementAddValidator() 
        {
            RuleFor(advertisement => advertisement.Title)
                .NotEmpty().WithMessage("Please enter a title !")
                .MinimumLength(3).WithMessage("Title can not be less than 3 characters !")
                .MaximumLength(100).WithMessage("Title can not be greater than 30 characters !");

            RuleFor(advertisement => advertisement.Description)
                .NotEmpty().WithMessage("Please enter a description !")
                .MinimumLength(3).WithMessage("Description can not be less than 3 characters !")
                .MaximumLength(250).WithMessage("Description can not be greater than 100 characters !");

            RuleFor(advertisement => advertisement.ImageUrl)
                .NotEmpty().WithMessage("Please enter a image url !")
                .MinimumLength(3).WithMessage("Image url can not be less than 3 characters !")
                .MaximumLength(250).WithMessage("Image url can not be greater than 100 characters !");
        }
    }
}