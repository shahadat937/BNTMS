using FluentValidation;

namespace SchoolManagement.Application.DTOs.CurrencyName.Validators
{
   public class CreateCurrencyNameDtoValidator: AbstractValidator<CreateCurrencyNameDto>
    {
        public CreateCurrencyNameDtoValidator()
        {
            Include(new ICurrencyNameDtoValidator());
        }
    }
}
