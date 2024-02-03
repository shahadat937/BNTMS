using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamAttemptType.Validators
{
    public class UpdateExamAttemptTypeDtoValidator: AbstractValidator<ExamAttemptTypeDto>
    {
        public UpdateExamAttemptTypeDtoValidator()
        {
            Include(new IExamAttemptTypeDtoValidator());

            RuleFor(c => c.ExamAttemptTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
