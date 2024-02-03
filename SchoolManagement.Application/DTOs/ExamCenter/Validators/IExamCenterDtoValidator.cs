using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamCenter.Validators
{
    public class IExamCenterDtoValidator: AbstractValidator<IExamCenterDto>
    {
        public IExamCenterDtoValidator()
        {
            RuleFor(c => c.ExamCenterName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(450).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
