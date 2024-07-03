using FluentValidation;
using Multishop.Catalog.Dtos.ContactDtos;

namespace Multishop.Catalog.ValidationRules.ContactValidationRules
{
    public class ContactUpdateValidator : AbstractValidator<ContactUpdateDto>
    {
        public ContactUpdateValidator() 
        {
            RuleFor(contact => contact.Id)
                .NotEmpty().WithMessage("Please enter contact Id !");

            RuleFor(contact => contact.IsRead)
                .NotEmpty().WithMessage("Please enter reading value !");

            RuleFor(contact => contact.ReadDate)
                .NotEmpty().WithMessage("Please enter read date !");
        }
    }
}