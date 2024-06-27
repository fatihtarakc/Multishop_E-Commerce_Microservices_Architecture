using FluentValidation;
using Multishop.UI.Areas.Admin.Models.ViewModels.DetailVMs;

namespace Multishop.UI.ValidationRules.DetailValidationRules
{
    public class DetailUpdateValidator : AbstractValidator<DetailUpdateVM>
    {
        public DetailUpdateValidator() 
        {
            RuleFor(detail => detail.Id)
               .NotEmpty().WithMessage("Please enter an Id !");

            RuleFor(detail => detail.Description)
                .NotEmpty().WithMessage("Please enter a description !")
                .MinimumLength(5).WithMessage("Description can not be less than 5 characters !")
                .MaximumLength(100).WithMessage("Description can not be greater than 100 characters !");

            RuleFor(detail => detail.Features)
                .NotEmpty().WithMessage("Please enter a features !")
                .MinimumLength(10).WithMessage("Features can not be less than 10 characters !")
                .MaximumLength(250).WithMessage("Features can not be greater than 250 characters !");

            RuleFor(detail => detail.ProductId)
               .NotEmpty().WithMessage("Please enter a productId !");
        }
    }
}