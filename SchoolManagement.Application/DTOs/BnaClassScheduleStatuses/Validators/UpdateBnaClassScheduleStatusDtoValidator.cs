using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.BnaClassScheduleStatuses.Validators
{
    public class UpdateBnaClassScheduleStatusDtoValidator : AbstractValidator<BnaClassScheduleStatusDto>
    {
        public UpdateBnaClassScheduleStatusDtoValidator()
        {
            Include(new IBnaClassScheduleStatusDtoValidator());

            RuleFor(b => b.BnaClassScheduleStatusId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}

 