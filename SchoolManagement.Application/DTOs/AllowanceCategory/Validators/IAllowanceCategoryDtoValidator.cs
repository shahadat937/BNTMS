using FluentValidation;

namespace SchoolManagement.Application.DTOs.AllowanceCategory.Validators
{
    public class IAllowanceCategoryDtoValidator: AbstractValidator<IAllowanceCategoryDto>
    {
        public IAllowanceCategoryDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
