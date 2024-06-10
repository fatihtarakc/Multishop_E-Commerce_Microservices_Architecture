using Cargo.Dto.CargoDtos;
using FluentValidation;

namespace Cargo.Business.ValidationRules.CargoValidationRules
{
    public class CargoAddValidator : AbstractValidator<CargoAddDto>
    {
        public CargoAddValidator() 
        {
        }
    }
}