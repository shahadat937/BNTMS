using FluentValidation;

namespace SchoolManagement.Application.DTOs.CurrencyName.Validators
{
    public class UpdateCurrencyNameDtoValidator: AbstractValidator<CurrencyNameDto>
    {
        public UpdateCurrencyNameDtoValidator()
        {
            Include(new ICurrencyNameDtoValidator());

            RuleFor(c => c.CurrencyNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
