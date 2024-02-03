using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamAttendance.Validators
{
    public class UpdateBnaExamAttendanceDtoValidator : AbstractValidator<BnaExamAttendanceDto>
    {
        public UpdateBnaExamAttendanceDtoValidator()
        {
            Include(new IBnaExamAttendanceDtoValidator());

            //RuleFor(p => p.BnaSemesterDurationId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaSemesterId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.TraineeId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaBatchId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaExamScheduleId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaSubjectNameId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.ExamTypeId).NotNull().WithMessage("{Propertyname} must be present");

        }
    }
}
