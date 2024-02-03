using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamSchedule.Validators
{
    public class UpdateBnaExamScheduleDtoValidator : AbstractValidator<BnaExamScheduleDto>
    {
        public UpdateBnaExamScheduleDtoValidator()
        {
            Include(new IBnaExamScheduleDtoValidator());

            RuleFor(p => p.BnaExamScheduleId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
