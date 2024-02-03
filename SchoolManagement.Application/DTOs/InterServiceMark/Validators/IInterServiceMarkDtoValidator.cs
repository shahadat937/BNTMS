using FluentValidation;

namespace SchoolManagement.Application.DTOs.InterServiceMark.Validators
{
    public class IInterServiceMarkDtoValidator: AbstractValidator<IInterServiceMarkDto>
    {
        public IInterServiceMarkDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
