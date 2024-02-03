using FluentValidation;

namespace SchoolManagement.Application.DTOs.WithdrawnType.Validators
{
    public class IWithdrawnTypeDtoValidator: AbstractValidator<IWithdrawnTypeDto>
    {
        public IWithdrawnTypeDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(450).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
