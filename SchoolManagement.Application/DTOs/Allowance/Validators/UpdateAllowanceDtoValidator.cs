using FluentValidation;

namespace SchoolManagement.Application.DTOs.Allowance.Validators
{
    public class UpdateAllowanceDtoValidator: AbstractValidator<AllowanceDto>
    {
        public UpdateAllowanceDtoValidator()
        {
            Include(new IAllowanceDtoValidator());

            //RuleFor(c => c.AllowanceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
