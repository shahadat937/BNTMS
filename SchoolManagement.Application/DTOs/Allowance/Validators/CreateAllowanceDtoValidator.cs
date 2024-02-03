using FluentValidation;

namespace SchoolManagement.Application.DTOs.Allowance.Validators
{
   public class CreateAllowanceDtoValidator: AbstractValidator<CreateAllowanceDto>
    {
        public CreateAllowanceDtoValidator()
        {
            Include(new IAllowanceDtoValidator());
        }
    }
}
