using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamInstructorAssign.Validators
{
    public class UpdateBnaExamInstructorAssignDtoValidator : AbstractValidator<BnaExamInstructorAssignDto>
    {
        public UpdateBnaExamInstructorAssignDtoValidator()
        {
            //Include(new IBnaExamInstructorAssignDtoValidator());

            //RuleFor(c => c.BnaExamInstructorAssignname).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
