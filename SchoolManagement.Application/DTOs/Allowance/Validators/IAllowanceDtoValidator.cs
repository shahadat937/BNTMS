using FluentValidation;

namespace SchoolManagement.Application.DTOs.Allowance.Validators
{
    public class IAllowanceDtoValidator: AbstractValidator<IAllowanceDto>
    {
        public IAllowanceDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
