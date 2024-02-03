using FluentValidation;

namespace SchoolManagement.Application.DTOs.FamilyInfo.Validators
{
    public class IFamilyInfoDtoValidator: AbstractValidator<IFamilyInfoDto>
    {
        public IFamilyInfoDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
