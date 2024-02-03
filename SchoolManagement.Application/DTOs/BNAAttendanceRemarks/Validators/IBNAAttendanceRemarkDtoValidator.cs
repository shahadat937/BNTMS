using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaAttendanceRemarks.Validators
{  
    public class IBnaAttendanceRemarkDtoValidator : AbstractValidator<IBnaAttendanceRemarkDto>
    { 
        public IBnaAttendanceRemarkDtoValidator() 
        {
            //RuleFor(c => c.AttendanceRemarksCause) 
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
