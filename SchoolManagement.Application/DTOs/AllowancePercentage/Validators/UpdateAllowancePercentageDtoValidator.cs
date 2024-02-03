using FluentValidation;

namespace SchoolManagement.Application.DTOs.AllowancePercentage.Validators
{
    public class UpdateAllowancePercentageDtoValidator: AbstractValidator<AllowancePercentageDto>
    {
        public UpdateAllowancePercentageDtoValidator()
        {
            Include(new IAllowancePercentageDtoValidator());

            RuleFor(c => c.AllowancePercentageId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
