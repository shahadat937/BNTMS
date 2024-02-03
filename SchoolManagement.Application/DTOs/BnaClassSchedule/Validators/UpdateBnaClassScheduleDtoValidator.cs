using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassSchedule.Validators
{
    public class UpdateBnaClassScheduleDtoValidator : AbstractValidator<BnaClassScheduleDto>
    {
        public UpdateBnaClassScheduleDtoValidator() 
        {
            Include(new IBnaClassScheduleDtoValidator());

            //RuleFor(p => p.BnaBatchId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSubjectNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.ClassPeriodId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSemesterId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
