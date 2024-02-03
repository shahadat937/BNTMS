using FluentValidation;

namespace SchoolManagement.Application.DTOs.Attendance.Validators
{
    public class IAttendanceDtoValidator : AbstractValidator<IAttendanceDto>
    {
        public IAttendanceDtoValidator()
        {
            //RuleFor(p => p.ClassPeriodId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.BnaSubjectNameId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.BnaAttendanceRemarksId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.ClassRoutineId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            

        }
    }
}
