using FluentValidation;
using Multishop.UI.Areas.Admin.Models.ViewModels.OfferVMs;

namespace Multishop.UI.ValidationRules.OfferValidationRules
{
    public class OfferAddValidator : AbstractValidator<OfferAddVM>
    {
        public OfferAddValidator() 
        {
            RuleFor(offer => offer.Title)
                .NotEmpty().WithMessage("Please enter a title !")
                .MinimumLength(3).WithMessage("Title can not be less than 3 characters !")
                .MaximumLength(30).WithMessage("Title can not be greater than 30 characters !");

            RuleFor(offer => offer.SubTitle)
                .NotEmpty().WithMessage("Please enter a subtitle !")
                .MinimumLength(3).WithMessage("Subtitle can not be less than 3 characters !")
                .MaximumLength(50).WithMessage("Subtitle can not be greater than 50 characters !");

            RuleFor(offer => offer.ImageUrl)
                .NotEmpty().WithMessage("Please enter an url !")
                .MinimumLength(10).WithMessage("Url can not be less than 10 characters")
                .MaximumLength(250).WithMessage("Url can not be greater than 250 characters");
        }
    }
}