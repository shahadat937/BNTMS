using FluentValidation;


namespace SchoolManagement.Application.DTOs.CourseBudgetAllocation.Validators
{
    public class UpdateCourseBudgetAllocationDtoValidator : AbstractValidator<CourseBudgetAllocationDto>
    {
        public UpdateCourseBudgetAllocationDtoValidator()
        {
            Include(new ICourseBudgetAllocationDtoValidator());

            RuleFor(p => p.CourseBudgetAllocationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}