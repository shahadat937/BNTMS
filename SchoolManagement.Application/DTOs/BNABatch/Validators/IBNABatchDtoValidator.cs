using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaBatch.Validators
{ 
    public class IBnaBatchDtoValidator: AbstractValidator<IBnaBatchDto>
    {
        public IBnaBatchDtoValidator()
        {
            RuleFor(b => b.BatchName)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
