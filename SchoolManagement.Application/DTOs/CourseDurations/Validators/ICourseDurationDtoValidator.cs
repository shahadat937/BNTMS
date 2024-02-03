using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseDurations.Validators
{
    public class ICourseDurationDtoValidator : AbstractValidator<ICourseDurationDto>
    {
        public ICourseDurationDtoValidator()
        {
            //RuleFor(p => p.Course)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
