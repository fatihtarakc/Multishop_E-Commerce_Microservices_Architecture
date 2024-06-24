using FluentValidation;
using Multishop.Catalog.Dtos.OfferDtos;

namespace Multishop.Catalog.ValidationRules.OfferValidationRules
{
    public class OfferAddValidator : AbstractValidator<OfferAddDto>
    {
        public OfferAddValidator() 
        {
        }
    }
}