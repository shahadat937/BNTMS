using FluentValidation;

namespace SchoolManagement.Application.DTOs.Attendance.Validators
{
    public class CreateAttendanceDtoValidator : AbstractValidator<CreateAttendanceDto>
    {
        public CreateAttendanceDtoValidator()
        {
            Include(new IAttendanceDtoValidator());
        }
    }
}
