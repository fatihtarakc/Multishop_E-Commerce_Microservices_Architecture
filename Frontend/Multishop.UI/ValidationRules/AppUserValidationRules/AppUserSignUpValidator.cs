using FluentValidation;
using Multishop.UI.Models.ViewModels.AppUserVMs;

namespace Multishop.UI.ValidationRules.AppUserValidationRules
{
    public class AppUserSignUpValidator : AbstractValidator<AppUserSignUpVM>
    {
        public AppUserSignUpValidator() 
        {
            RuleFor(appUser => appUser.Name)
                .NotEmpty().WithMessage("Please enter your name !")
                .MinimumLength(2).WithMessage("Name cannot be less than 2 characters !")
                .MaximumLength(20).WithMessage("Name cannot be greater than 20 characters !");

            RuleFor(appUser => appUser.Surname)
                .NotEmpty().WithMessage("Please enter your surname !")
                .MinimumLength(2).WithMessage("Surname cannot be less than 2 characters !")
                .MaximumLength(20).WithMessage("Surname cannot be greater than 20 characters !");

            RuleFor(appUser => appUser.Username)
                .NotEmpty().WithMessage("Please enter your username !")
                .Must(TRCharacterControl).WithMessage("Turkish charachters cannot be used for username !")
                .MinimumLength(5).WithMessage("Username cannot be less than 5 characters !")
                .MaximumLength(20).WithMessage("Username cannot be greater than 20 characters !");

            RuleFor(appUser => appUser.Email)
                .NotEmpty().WithMessage("Please enter your email !")
                .EmailAddress().WithMessage("Email address is invalid !")
                .Must(TRCharacterControl).WithMessage("Turkish charachters cannot be used for email !")
                .MinimumLength(5).WithMessage("Email can notbe less than 5 characters !")
                .MaximumLength(50).WithMessage("Email cannot be greater than 50 characters !");

            RuleFor(appUser => appUser.Password)
                .NotEmpty().WithMessage("Please enter your password !")
                .Equal(appUser => appUser.ConfirmPassword).WithMessage("Password not equal to re-password !")
                .Must(PasswordUpperLetterControl).WithMessage("Password must include min one upper letter !")
                .Must(PasswordLowerLetterControl).WithMessage("Password must include min one lower letter !")
                .Must(PasswordNumberControl).WithMessage("Password must include min one number !")
                .Must(PasswordNonAlphaNumericControl).WithMessage("Password must include min one non alpha numeric character !")
                .MinimumLength(8).WithMessage("Password cannot be less than 8 characters !")
                .MaximumLength(16).WithMessage("Password cannot be greater than 16 characters !");

            RuleFor(appUser => appUser.ConfirmPassword)
                .NotEmpty().WithMessage("Please enter your re-password !")
                .MinimumLength(8).WithMessage("Re-password cannot be less than 8 characters !")
                .MaximumLength(16).WithMessage("Re-password cannot be greater than 16 characters !");
        }

        public static bool TRCharacterControl(string info)
        {
            char[] trCharacters = ['ç', 'Ç', 'ğ', 'Ğ', 'ı', 'İ', 'ö', 'Ö', 'ş', 'Ş', 'ü', 'Ü'];

            for (int i = 0; i < trCharacters.Length; i++)
            {
                if (info.Contains(trCharacters[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool PasswordUpperLetterControl(string password)
        {
            const string upperLetter = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ";

            for (int i = 0; i < upperLetter.Length; i++)
            {
                if (password.Contains(upperLetter[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool PasswordLowerLetterControl(string password)
        {
            const string smallLetter = "abcçdefgğhıijklmnoöpqrsştuüvwxyz";

            for (int i = 0; i < smallLetter.Length; i++)
            {
                if (password.Contains(smallLetter[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool PasswordNumberControl(string password)
        {
            const string number = "0123456789";

            for (int i = 0; i < number.Length; i++)
            {
                if (password.Contains(number[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool PasswordNonAlphaNumericControl(string password)
        {
            const string nonAlphaNumeric = "!'^%&()[]{}=<>|~#*/-+?";

            for (int i = 0; i < nonAlphaNumeric.Length; i++)
            {
                if (password.Contains(nonAlphaNumeric[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}