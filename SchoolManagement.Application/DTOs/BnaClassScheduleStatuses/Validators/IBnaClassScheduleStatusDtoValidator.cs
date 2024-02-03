using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.BnaClassScheduleStatuses.Validators
{ 
    public class IBnaClassScheduleStatusDtoValidator : AbstractValidator<IBnaClassScheduleStatusDto>
    {
        public IBnaClassScheduleStatusDtoValidator() 
        { 
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
 