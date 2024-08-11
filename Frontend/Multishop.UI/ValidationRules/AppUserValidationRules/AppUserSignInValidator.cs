using FluentValidation;
using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.ValidationRules.AppUserValidationRules
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInVM>
    {
        public AppUserSignInValidator()
        {
            RuleFor(appUser => appUser.Username)
                .NotEmpty().WithMessage("Please enter your username !");

            RuleFor(appUser => appUser.Password)
                .NotEmpty().WithMessage("Please enter your password !");
        }
    }
}