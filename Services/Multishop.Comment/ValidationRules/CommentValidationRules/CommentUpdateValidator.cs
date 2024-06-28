using FluentValidation;
using Multishop.Comment.Dtos.CommentDtos;

namespace Multishop.Comment.ValidationRules.CommentValidationRules
{
    public class CommentUpdateValidator : AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateValidator() 
        {
            RuleFor(comment => comment.Id)
               .NotEmpty().WithMessage("Please enter an Id !");

            RuleFor(comment => comment.NameSurname)
                .NotEmpty().WithMessage("Please enter your name and surname !")
                .MinimumLength(5).WithMessage("Name and surname can not be less than 5 characters !")
                .MaximumLength(50).WithMessage("Name and surname can not be greater than 50 characters !");

            RuleFor(comment => comment.Email)
                .NotEmpty().WithMessage("Please enter your email !")
                .Must(TRCharacterControl).WithMessage("Turkish charachters cannot use !")
                .MinimumLength(5).WithMessage("Email can not be less than 5 characters !")
                .MaximumLength(50).WithMessage("Email can not be greater than 50 characters !");

            RuleFor(comment => comment.Review)
                .NotEmpty().WithMessage("Please enter your review !")
                .MinimumLength(10).WithMessage("Review can not be less than 10 characters !")
                .MaximumLength(250).WithMessage("Review can not be greater than 250 characters !");

            RuleFor(comment => comment.Rating)
                .GreaterThanOrEqualTo(0).WithMessage("Rating value greater than or equal to 0 !")
                .LessThanOrEqualTo(5).WithMessage("Rating value less than or equal to 5 !");

            RuleFor(comment => comment.IsActive)
               .NotEmpty().WithMessage("Comment active value can not be null or empty !");

            RuleFor(comment => comment.ProductId)
                .NotEmpty().WithMessage("Please enter a productId !")
                .MinimumLength(24).WithMessage("ProductId can not be less than 24 characters !")
                .MaximumLength(24).WithMessage("ProductId can not be greater than 24 characters !");
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
    }
}