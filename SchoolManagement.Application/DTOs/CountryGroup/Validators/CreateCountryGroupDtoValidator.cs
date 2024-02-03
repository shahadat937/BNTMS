using FluentValidation;

namespace SchoolManagement.Application.DTOs.CountryGroup.Validators
{
   public class CreateCountryGroupDtoValidator: AbstractValidator<CreateCountryGroupDto>
    {
        public CreateCountryGroupDtoValidator()
        {
            Include(new ICountryGroupDtoValidator());
        }
    }
}
