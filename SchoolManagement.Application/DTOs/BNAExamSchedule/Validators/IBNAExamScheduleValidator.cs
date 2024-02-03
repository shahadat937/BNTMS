using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamSchedule.Validators
{
    public class IBnaExamScheduleDtoValidator : AbstractValidator<IBnaExamScheduleDto>
    {
        public IBnaExamScheduleDtoValidator()
        {
            //RuleFor(p => p.BoardId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull();

            //RuleFor(p => p.Semestername)
            //    .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
