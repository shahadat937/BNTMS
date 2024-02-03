using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamCenterSelection.Validators
{
    public class UpdateExamCenterSelectionDtoValidator: AbstractValidator<ExamCenterSelectionDto>
    {
        public UpdateExamCenterSelectionDtoValidator()
        {
            Include(new IExamCenterSelectionDtoValidator());

            RuleFor(c => c.ExamCenterSelectionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
