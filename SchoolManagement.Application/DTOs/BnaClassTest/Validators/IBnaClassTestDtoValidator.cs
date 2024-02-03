using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassTest.Validators
{
    public class IBnaClassTestDtoValidator : AbstractValidator<IBnaClassTestDto>
    {
        public IBnaClassTestDtoValidator()
        {
            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
