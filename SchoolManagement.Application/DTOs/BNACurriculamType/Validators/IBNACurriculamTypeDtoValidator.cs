using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaCurriculamType.Validators
{
    public class IBnaCurriculamTypeDtoValidator: AbstractValidator<IBnaCurriculamTypeDto>
    {
        public IBnaCurriculamTypeDtoValidator()
        {
            RuleFor(c => c.CurriculumType)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
