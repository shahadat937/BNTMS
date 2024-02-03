using FluentValidation;


namespace SchoolManagement.Application.DTOs.Branch.Validators
{
    public class UpdateBranchDtoValidator : AbstractValidator<BranchDto>
    {
        public UpdateBranchDtoValidator()
        {
            Include(new IBranchDtoValidator());

            RuleFor(p => p.BranchId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}