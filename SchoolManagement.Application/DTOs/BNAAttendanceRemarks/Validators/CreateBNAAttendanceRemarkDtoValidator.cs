using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaAttendanceRemarks.Validators
{
    public class CreateBnaAttendanceRemarkDtoValidator : AbstractValidator<CreateBnaAttendanceRemarkDto>
    {
        public CreateBnaAttendanceRemarkDtoValidator()
        {
            Include(new IBnaAttendanceRemarkDtoValidator());
        }
    } 
}
