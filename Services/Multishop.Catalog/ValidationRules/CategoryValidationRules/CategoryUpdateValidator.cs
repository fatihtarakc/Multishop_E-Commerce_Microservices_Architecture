using FluentValidation;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.ValidationRules.CategoryValidationRules
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator() 
        {
            RuleFor(category => category.Id)
               .NotEmpty().WithMessage("Please enter an Id !");

            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Please enter a category name !")
                .MinimumLength(3).WithMessage("Category name can not be less than 3 characters !")
                .MaximumLength(50).WithMessage("Category name can not be greater than 50 characters !");
        }
    }
}