using Entities.Models;
using FluentValidation;

namespace Services.ValidationRules.FluentValidation
{
    public class VehicleTypeValidator : AbstractValidator<VehicleType>
    {
        public VehicleTypeValidator()
        {
            RuleFor(vt=>vt.TypeName).NotEmpty().NotNull().WithMessage("TypeName cannot be empty or null");
        }
    }
}
