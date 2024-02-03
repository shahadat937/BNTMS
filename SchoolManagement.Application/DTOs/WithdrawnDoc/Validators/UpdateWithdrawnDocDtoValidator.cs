using FluentValidation;

namespace SchoolManagement.Application.DTOs.WithdrawnDoc.Validators
{
    public class UpdateWithdrawnDocDtoValidator : AbstractValidator<WithdrawnDocDto>
    {
        public UpdateWithdrawnDocDtoValidator()
        {
            Include(new IWithdrawnDocDtoValidator());

            RuleFor(p => p.WithdrawnDocId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
