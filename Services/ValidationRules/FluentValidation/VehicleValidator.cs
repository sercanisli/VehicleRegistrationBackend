using Entities.Models;
using FluentValidation;

namespace Services.ValidationRules.FluentValidation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.ModelId).NotEmpty().NotNull().WithMessage("ModelId cannot be empty or null");
            RuleFor(v => v.BrandId).NotEmpty().NotNull().WithMessage("BrandId cannot be empty or null");
            RuleFor(v => v.VehicleTypeId).NotEmpty().NotNull().WithMessage("VehicleTypeId cannot be empty or null");
            RuleFor(v => v.Plate).NotEmpty().NotNull().WithMessage("VehicleTypeId cannot be empty or null")
                .MaximumLength(9).WithMessage("The plate must have a maximum of 9 characters.")
                .MinimumLength(5).WithMessage("The plate must have a minimum of 5 characters.")
                .Matches(@"^\d{2}(?=.*[A-Z])[A-Z]{1,3}\d{2,}$")
                .WithMessage("Plate number invalid format. First two characters must be numbers, next character(s) must be uppercase letters, last two characters must be numbers.");
            RuleFor(v=>v.Nickname).NotEmpty().NotNull().WithMessage("Nickname cannot be empty or null");
            RuleFor(v=>v.Color).NotEmpty().NotNull().WithMessage("Color cannot be empty or null");
        }
    }
}
