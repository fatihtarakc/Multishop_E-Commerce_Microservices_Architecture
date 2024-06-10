using Cargo.Dto.CompanyDtos;
using FluentValidation;

namespace Cargo.Business.ValidationRules.CompanyValidationRules
{
    public class CompanyAddValidator : AbstractValidator<CompanyAddDto>
    {
        public CompanyAddValidator() 
        {
        }
    }
}