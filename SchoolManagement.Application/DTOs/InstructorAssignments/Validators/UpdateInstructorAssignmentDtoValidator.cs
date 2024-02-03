using FluentValidation;

namespace SchoolManagement.Application.DTOs.InstructorAssignments.Validators
{
    public class UpdateInstructorAssignmentDtoValidator : AbstractValidator<InstructorAssignmentDto>
    {
        public UpdateInstructorAssignmentDtoValidator()
        { 
            //Include(new IInstructorAssignmentDtoValidator());

            //RuleFor(c => c.InstructorAssignmentName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
