using FluentValidation;

namespace SchoolManagement.Application.DTOs.InterServiceMark.Validators
{
    public class UpdateInterServiceMarkDtoValidator: AbstractValidator<InterServiceMarkDto>
    {
        public UpdateInterServiceMarkDtoValidator()
        {
            Include(new IInterServiceMarkDtoValidator());

            //RuleFor(c => c.InterServiceMarkId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
