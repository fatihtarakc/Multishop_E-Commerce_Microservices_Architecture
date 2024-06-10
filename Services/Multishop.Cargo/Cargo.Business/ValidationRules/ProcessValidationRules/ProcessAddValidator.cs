using Cargo.Dto.ProcessDtos;
using FluentValidation;

namespace Cargo.Business.ValidationRules.ProcessValidationRules
{
    public class ProcessAddValidator : AbstractValidator<ProcessAddDto>
    {
        public ProcessAddValidator() 
        {
        }
    }
}