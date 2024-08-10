using FluentValidation;
using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.ValidationRules.AppUserValidationRules
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInVM>
    {
        public AppUserSignInValidator()
        {
            RuleFor(appUser => appUser.Email)
                .NotEmpty().WithMessage("Please enter your email !")
                .EmailAddress().WithMessage("Email address is invalid !");

            RuleFor(appUser => appUser.Password)
                .NotEmpty().WithMessage("Please enter your password !");
        }
    }
}