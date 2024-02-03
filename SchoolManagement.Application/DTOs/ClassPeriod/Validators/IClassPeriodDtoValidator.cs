using FluentValidation;

namespace SchoolManagement.Application.DTOs.ClassPeriod.Validators
{ 
    public class IClassPeriodDtoValidator : AbstractValidator<IClassPeriodDto>
    {
        public IClassPeriodDtoValidator()
        {
            RuleFor(c => c.PeriodName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
