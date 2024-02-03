using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamAttemptType.Validators
{
    public class IExamAttemptTypeDtoValidator: AbstractValidator<IExamAttemptTypeDto>
    {
        public IExamAttemptTypeDtoValidator()
        {
            RuleFor(c => c.ExamAttemptTypeName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(450).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
