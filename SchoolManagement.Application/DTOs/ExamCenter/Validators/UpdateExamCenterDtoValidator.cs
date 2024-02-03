using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamCenter.Validators
{
    public class UpdateExamCenterDtoValidator: AbstractValidator<ExamCenterDto>
    {
        public UpdateExamCenterDtoValidator()
        {
            Include(new IExamCenterDtoValidator());

            RuleFor(c => c.ExamCenterId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
