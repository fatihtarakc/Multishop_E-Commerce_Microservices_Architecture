using Cargo.Dto.CompanyDtos;
using FluentValidation;

namespace Cargo.Business.ValidationRules.CompanyValidationRules
{
    public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateValidator() 
        {
        }
    }
}