using FluentValidation;
using Multishop.UI.Models.ViewModels.CommentVMs;

namespace Multishop.UI.ValidationRules.CommentValidationRules
{
    public class CommentAddValidator : AbstractValidator<CommentAddVM>
    {
        public CommentAddValidator() 
        {
        }
    }
}