using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaAttendancePeriod.Validators
{
    public class CreateBnaAttendancePeriodDtoValidator : AbstractValidator<CreateBnaAttendancePeriodDto>
    {
        public CreateBnaAttendancePeriodDtoValidator()
        {
            Include(new IBnaAttendancePeriodDtoValidator());
        }
    }
}
