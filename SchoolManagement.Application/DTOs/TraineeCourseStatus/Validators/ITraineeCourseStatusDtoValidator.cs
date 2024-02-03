using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeCourseStatus.Validators
{
    public class ITraineeCourseStatusDtoValidator : AbstractValidator<ITraineeCourseStatusDto>
    {
        public ITraineeCourseStatusDtoValidator()
        {
            RuleFor(p => p.TraineeCourseStatusName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
