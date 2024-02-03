using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassSchedule.Validators
{
    public class CreateBnaClassScheduleDtoValidator : AbstractValidator<CreateBnaClassScheduleDto>
    {
        public CreateBnaClassScheduleDtoValidator()
        {
            Include(new IBnaClassScheduleDtoValidator());
        }
    }
}
