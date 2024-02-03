using FluentValidation;

namespace SchoolManagement.Application.DTOs.BaseNames.Validators
{
    public class UpdateBaseNameDtoValidator : AbstractValidator<BaseNameDto>
    {
        public UpdateBaseNameDtoValidator()
        {
            Include(new IBaseNameDtoValidator()); 

            RuleFor(p => p.BaseNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
