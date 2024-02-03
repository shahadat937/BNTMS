using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassSectionSelection.Validators
{
    public class IBnaClassSectionSelectionDtoValidator : AbstractValidator<IBnaClassSectionSelectionDto>
    {
        public IBnaClassSectionSelectionDtoValidator() 
        {
            RuleFor(p => p.SectionName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
 