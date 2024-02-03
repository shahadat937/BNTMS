using FluentValidation;

namespace SchoolManagement.Application.DTOs.Attendance.Validators
{
    public class CreateAttendanceListDtoValidator : AbstractValidator<CreateAttendanceListDto> 
    {
        public CreateAttendanceListDtoValidator()
        {
            Include(new IAttendanceDtoValidator());
        }
    }
}
