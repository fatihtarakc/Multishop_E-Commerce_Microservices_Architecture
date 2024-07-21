using FluentValidation;
using Multishop.IdentityServer4.Dtos.AppUserDtos;

namespace Multishop.IdentityServer4.ValidationRules
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator() 
        {
            RuleFor(appUser => appUser.Email)
                .NotEmpty().WithMessage("Please enter your email !");

            RuleFor(appUser => appUser.Password)
                .NotEmpty().WithMessage("Please enter your password !");

            RuleFor(appUser => appUser.RememberMe)
                .NotEmpty().WithMessage("Remember me value can be only true or false !");
        }
    }
}