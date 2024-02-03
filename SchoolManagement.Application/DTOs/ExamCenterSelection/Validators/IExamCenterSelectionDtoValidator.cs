using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamCenterSelection.Validators
{
    public class IExamCenterSelectionDtoValidator: AbstractValidator<IExamCenterSelectionDto>
    {
        public IExamCenterSelectionDtoValidator()
        {
            //RuleFor(c => c.ExamCenterSelectionName)
            //   .NotEmpty().WithMessage("{PropertyName} is required.")
            //   .MaximumLength(450).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
