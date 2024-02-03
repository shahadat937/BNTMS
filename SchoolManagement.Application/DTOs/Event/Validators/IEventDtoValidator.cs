using FluentValidation;

namespace SchoolManagement.Application.DTOs.Event.Validators
{ 
    public class IEventDtoValidator: AbstractValidator<IEventDto>
    {
        public IEventDtoValidator()
        {
            RuleFor(b => b.EventDetails)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
