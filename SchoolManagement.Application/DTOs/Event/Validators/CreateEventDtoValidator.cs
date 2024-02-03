using FluentValidation;

namespace SchoolManagement.Application.DTOs.Event.Validators
{
    public class CreateEventDtoValidator : AbstractValidator<CreateEventDto>
    {
        public CreateEventDtoValidator()
        {
            Include(new IEventDtoValidator());
        }
    }
}
 