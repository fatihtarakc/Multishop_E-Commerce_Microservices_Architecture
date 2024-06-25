using FluentValidation;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.ValidationRules.BrandValidationRules
{
    public class BrandAddValidator : AbstractValidator<BrandAddDto>
    {
        public BrandAddValidator() 
        {
        }
    }
}