using FluentValidation;

namespace SchoolManagement.Application.DTOs.WithdrawnType.Validators
{
    public class UpdateWithdrawnTypeDtoValidator: AbstractValidator<WithdrawnTypeDto>
    {
        public UpdateWithdrawnTypeDtoValidator()
        {
            Include(new IWithdrawnTypeDtoValidator());

            RuleFor(c => c.WithdrawnTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
