using FluentValidation;

namespace SchoolManagement.Application.DTOs.TdecGroupResult.Validators
{
    public class UpdateTdecGroupResultDtoValidator : AbstractValidator<TdecGroupResultDto>
    {
        public UpdateTdecGroupResultDtoValidator()
        {
            Include(new ITdecGroupResultDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
