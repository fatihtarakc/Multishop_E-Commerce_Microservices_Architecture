using FluentValidation;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.ValidationRules.BrandValidationRules
{
    public class BrandUpdateValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateValidator() 
        {
        }
    }
}