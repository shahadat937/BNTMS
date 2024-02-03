using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamSchedule.Validators
{
    public class CreateBnaExamScheduleDtoValidator : AbstractValidator<CreateBnaExamScheduleDto>
    {
        public CreateBnaExamScheduleDtoValidator()
        {
            Include(new IBnaExamScheduleDtoValidator());
        }
    }
} 
