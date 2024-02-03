using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaBatch.Validators
{
    public class UpdateBnaBatchDtoValidator : AbstractValidator<BnaBatchDto>
    {
        public UpdateBnaBatchDtoValidator()
        {
            Include(new IBnaBatchDtoValidator()); 

            RuleFor(b => b.BnaBatchId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 