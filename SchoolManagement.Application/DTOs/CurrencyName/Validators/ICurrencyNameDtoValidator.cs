using FluentValidation;

namespace SchoolManagement.Application.DTOs.CurrencyName.Validators
{
    public class ICurrencyNameDtoValidator: AbstractValidator<ICurrencyNameDto>
    {
        public ICurrencyNameDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
