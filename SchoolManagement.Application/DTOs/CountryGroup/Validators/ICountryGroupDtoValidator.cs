using FluentValidation;

namespace SchoolManagement.Application.DTOs.CountryGroup.Validators
{
    public class ICountryGroupDtoValidator: AbstractValidator<ICountryGroupDto>
    {
        public ICountryGroupDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
