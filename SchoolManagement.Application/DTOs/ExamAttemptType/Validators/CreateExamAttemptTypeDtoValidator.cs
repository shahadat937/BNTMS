using FluentValidation;

namespace SchoolManagement.Application.DTOs.ExamAttemptType.Validators
{
   public class CreateExamAttemptTypeDtoValidator: AbstractValidator<CreateExamAttemptTypeDto>
    {
        public CreateExamAttemptTypeDtoValidator()
        {
            Include(new IExamAttemptTypeDtoValidator());
        }
    }
}
