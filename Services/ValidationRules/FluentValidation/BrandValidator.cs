using Entities.Models;
using FluentValidation;

namespace Services.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b=>b.Name).NotEmpty().NotNull().WithMessage("BrandName cannot be empty or null");
        }
    }
}
