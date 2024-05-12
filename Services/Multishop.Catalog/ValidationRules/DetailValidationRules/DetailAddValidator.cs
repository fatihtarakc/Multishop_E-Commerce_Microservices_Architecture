using FluentValidation;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.ValidationRules.DetailValidationRules
{
    public class DetailAddValidator : AbstractValidator<DetailAddDto>
    {
        public DetailAddValidator() 
        {
            RuleFor(detail => detail.Description)
                .NotEmpty().WithMessage("Please enter a description !")
                .MinimumLength(5).WithMessage("Description can not be less than 5 characters")
                .MaximumLength(100).WithMessage("Description can not be greater than 100 characters");

            RuleFor(detail => detail.Features)
                .NotEmpty().WithMessage("Please enter a features !")
                .MinimumLength(10).WithMessage("Features can not be less than 10 characters")
                .MaximumLength(250).WithMessage("Features can not be greater than 250 characters");
        }
    }
}