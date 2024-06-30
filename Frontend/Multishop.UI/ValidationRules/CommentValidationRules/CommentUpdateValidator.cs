using FluentValidation;
using Multishop.UI.Models.ViewModels.CommentVMs;

namespace Multishop.UI.ValidationRules.CommentValidationRules
{
    public class CommentUpdateValidator : AbstractValidator<CommentUpdateVM>
    {
        public CommentUpdateValidator()
        {
        }
    }
}