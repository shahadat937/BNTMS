using FluentValidation;

namespace SchoolManagement.Application.DTOs.NewAtempt.Validators
{
    public class INewAtemptDtoValidator: AbstractValidator<INewAtemptDto>
    {
        public INewAtemptDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(450).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
