using FluentValidation;

namespace SchoolManagement.Application.DTOs.CountryGroup.Validators
{
    public class UpdateCountryGroupDtoValidator: AbstractValidator<CountryGroupDto>
    {
        public UpdateCountryGroupDtoValidator()
        {
            Include(new ICountryGroupDtoValidator());

            RuleFor(c => c.CountryGroupId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
