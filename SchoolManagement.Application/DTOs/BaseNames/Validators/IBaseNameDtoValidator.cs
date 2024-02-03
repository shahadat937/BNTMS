using FluentValidation;

namespace SchoolManagement.Application.DTOs.BaseNames.Validators
{
    public class IBaseNameDtoValidator : AbstractValidator<IBaseNameDto>
    {
        public IBaseNameDtoValidator()
        {
            //RuleFor(p => p.BaseNames)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            //RuleFor(p => p.AdminAuthorityId)
            //   .NotEmpty().WithMessage("{PropertyName} is required.");

            //RuleFor(p => p.DivisionId)
            //   .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
