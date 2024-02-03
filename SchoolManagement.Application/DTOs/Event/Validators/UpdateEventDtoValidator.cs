using FluentValidation;

namespace SchoolManagement.Application.DTOs.Event.Validators
{
    public class UpdateEventDtoValidator : AbstractValidator<EventDto>
    {
        public UpdateEventDtoValidator()
        {
            Include(new IEventDtoValidator()); 

            RuleFor(b => b.EventId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 