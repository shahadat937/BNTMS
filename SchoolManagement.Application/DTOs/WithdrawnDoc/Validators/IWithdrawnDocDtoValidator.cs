using FluentValidation;

namespace SchoolManagement.Application.DTOs.WithdrawnDoc.Validators
{
    public class IWithdrawnDocDtoValidator : AbstractValidator<IWithdrawnDocDto>
    {
        public IWithdrawnDocDtoValidator()
        {
            RuleFor(p => p.WithdrawnDocName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
