using FluentValidation;

namespace SchoolManagement.Application.DTOs.Attendance.Validators
{
    public class UpdateAttendanceDtoValidator : AbstractValidator<AttendanceDto>
    {
        public UpdateAttendanceDtoValidator() 
        {
            Include(new IAttendanceDtoValidator());

            //RuleFor(p => p.ClassPeriodId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSubjectNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaAttendanceRemarksId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.ClassRoutineId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
