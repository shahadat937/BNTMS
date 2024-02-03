using FluentValidation;

namespace SchoolManagement.Application.DTOs.MarkType.Validators
{
    public class IMarkTypeDtoValidator : AbstractValidator<IMarkTypeDto>
    {
        public IMarkTypeDtoValidator()
        {
            RuleFor(p => p.TypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
