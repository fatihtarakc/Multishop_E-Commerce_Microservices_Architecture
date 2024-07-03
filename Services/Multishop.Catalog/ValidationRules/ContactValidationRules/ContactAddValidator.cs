using FluentValidation;
using Multishop.Catalog.Dtos.ContactDtos;

namespace Multishop.Catalog.ValidationRules.ContactValidationRules
{
    public class ContactAddValidator : AbstractValidator<ContactAddDto>
    {
        public ContactAddValidator() 
        {
            RuleFor(contact => contact.NameSurname)
                .NotEmpty().WithMessage("Please enter a name surname !")
                .MinimumLength(5).WithMessage("Name Surname can not be less than 5 characters !")
                .MaximumLength(50).WithMessage("Name Surname can not be greater than 50 characters !");

            RuleFor(contact => contact.Email)
                .NotEmpty().WithMessage("Please enter a email !")
                .MinimumLength(5).WithMessage("Email can not be less than 5 characters !")
                .MaximumLength(50).WithMessage("Email can not be greater than 50 characters !");

            RuleFor(contact => contact.Subject)
                .NotEmpty().WithMessage("Please enter a subject !")
                .MinimumLength(5).WithMessage("Subject can not be less than 5 characters !")
                .MaximumLength(50).WithMessage("Subject can not be greater than 50 characters !");

            RuleFor(contact => contact.Message)
                .NotEmpty().WithMessage("Please enter a message !")
                .MinimumLength(10).WithMessage("Message can not be less than 10 characters !")
                .MaximumLength(250).WithMessage("Message can not be greater than 250 characters !");
        }
    }
}