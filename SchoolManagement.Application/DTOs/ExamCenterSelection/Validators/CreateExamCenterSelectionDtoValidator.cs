using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamCenterSelection.Validators
{
   public class CreateExamCenterSelectionDtoValidator: AbstractValidator<CreateExamCenterSelectionDto>
    {
        public CreateExamCenterSelectionDtoValidator()
        {
            Include(new IExamCenterSelectionDtoValidator());
        }
    }
}
