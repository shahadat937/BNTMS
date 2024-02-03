using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamInstructorAssign.Validators
{
    public class IBnaExamInstructorAssignDtoValidator : AbstractValidator<IBnaExamInstructorAssignDto>
    {
        public IBnaExamInstructorAssignDtoValidator() 
        {
            //RuleFor(c => c.BnaExamInstructorAssignname)
            //   .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
