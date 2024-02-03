using FluentValidation;

namespace SchoolManagement.Application.DTOs.NewAtempt.Validators
{
    public class UpdateNewAtemptDtoValidator: AbstractValidator<NewAtemptDto>
    {
        public UpdateNewAtemptDtoValidator()
        {
            Include(new INewAtemptDtoValidator());

            RuleFor(c => c.NewAtemptId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
