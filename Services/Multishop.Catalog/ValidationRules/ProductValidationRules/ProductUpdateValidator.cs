using FluentValidation;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.ValidationRules.ProductValidationRules
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator() 
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Please enter a product name !")
                .MinimumLength(3).WithMessage("Product name can not be less than 3 characters !")
                .MaximumLength(30).WithMessage("Product name can not be greater than 30 characters !");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Please enter a product price !")
                .GreaterThanOrEqualTo(1).WithMessage("Product price can not be zero or negative vaule !");
        }
    }
}