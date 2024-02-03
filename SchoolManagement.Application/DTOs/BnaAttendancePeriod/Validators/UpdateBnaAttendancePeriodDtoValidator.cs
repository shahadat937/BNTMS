using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaAttendancePeriod.Validators
{
    public class UpdateBnaAttendancePeriodDtoValidator : AbstractValidator<BnaAttendancePeriodDto>
    {
        public UpdateBnaAttendancePeriodDtoValidator()
        {
            Include(new IBnaAttendancePeriodDtoValidator());

            RuleFor(p => p.BnaAttendancePeriodId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
