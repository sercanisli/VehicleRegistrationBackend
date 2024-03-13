using Entities.Models;
using FluentValidation;

namespace Services.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m=>m.BrandId).NotEmpty().NotNull().WithMessage("BrandId cannot be empty or null");
            RuleFor(m=>m.ModelName).NotEmpty().NotNull().WithMessage("ModelName cannot be empty or null");
            RuleFor(m=>m.ModelYear).NotEmpty().NotNull().WithMessage("ModelYear cannot be empty or null");
        }
    }
}
