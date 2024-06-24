using FluentValidation;
using Multishop.Catalog.Dtos.OfferDtos;

namespace Multishop.Catalog.ValidationRules.OfferValidationRules
{
    public class OfferUpdateValidator : AbstractValidator<OfferUpdateDto>
    {
        public OfferUpdateValidator() 
        {
        }
    }
}