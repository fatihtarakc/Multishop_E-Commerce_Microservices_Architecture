using FluentValidation;
using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;

namespace Multishop.UI.ValidationRules.ProductValidationRules
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateVM>
    {
        public ProductUpdateValidator() 
        {
            RuleFor(product => product.Id)
               .NotEmpty().WithMessage("Please enter an Id !");

            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Please enter a product name !")
                .MinimumLength(3).WithMessage("Product name can not be less than 3 characters !")
                .MaximumLength(50).WithMessage("Product name can not be greater than 50 characters !");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Please enter a product price !")
                .GreaterThanOrEqualTo(1).WithMessage("Product price can not be zero or negative vaule !");

            RuleFor(product => product.CategoryId)
               .NotEmpty().WithMessage("Please enter a categoryId !");
        }
    }
}