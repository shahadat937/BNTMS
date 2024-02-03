using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamCenter.Validators
{
   public class CreateExamCenterDtoValidator: AbstractValidator<CreateExamCenterDto>
    {
        public CreateExamCenterDtoValidator()
        {
            Include(new IExamCenterDtoValidator());
        }
    }
}
