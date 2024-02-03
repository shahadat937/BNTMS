using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaAttendanceRemarks.Validators
{ 
    public class UpdateBnaAttendanceRemarkDtoValidator : AbstractValidator<BnaAttendanceRemarkDto>
    {
        public UpdateBnaAttendanceRemarkDtoValidator()
        {  
            Include(new IBnaAttendanceRemarkDtoValidator());

            RuleFor(c => c.AttendanceRemarksCause).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
