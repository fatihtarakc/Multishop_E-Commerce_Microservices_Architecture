using Cargo.Dto.ProcessDtos;
using FluentValidation;

namespace Cargo.Business.ValidationRules.ProcessValidationRules
{
    public class ProcessUpdateValidator : AbstractValidator<ProcessUpdateDto>
    {
        public ProcessUpdateValidator() 
        {
        }
    }
}