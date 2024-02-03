using FluentValidation;

namespace SchoolManagement.Application.DTOs.AllowancePercentage.Validators
{
    public class IAllowancePercentageDtoValidator: AbstractValidator<IAllowancePercentageDto>
    {
        public IAllowancePercentageDtoValidator()
        {
            RuleFor(c => c.AllowanceName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
