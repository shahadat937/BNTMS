using FluentValidation;


namespace SchoolManagement.Application.DTOs.BudgetAllocation.Validators
{
    public class UpdateBudgetAllocationDtoValidator : AbstractValidator<BudgetAllocationDto>
    {
        public UpdateBudgetAllocationDtoValidator()
        {
            Include(new IBudgetAllocationDtoValidator());

            RuleFor(p => p.BudgetAllocationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}