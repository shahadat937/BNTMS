using FluentValidation;

namespace SchoolManagement.Application.DTOs.AllowancePercentage.Validators
{
   public class CreateAllowancePercentageDtoValidator: AbstractValidator<CreateAllowancePercentageDto>
    {
        public CreateAllowancePercentageDtoValidator()
        {
            Include(new IAllowancePercentageDtoValidator());
        }
    }
}
