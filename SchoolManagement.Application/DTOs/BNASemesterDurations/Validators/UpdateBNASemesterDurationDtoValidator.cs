using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaSemesterDurations.Validators
{
    public class UpdateBnaSemesterDurationDtoValidator : AbstractValidator<BnaSemesterDurationDto>
    {
        public UpdateBnaSemesterDurationDtoValidator()
        {
            Include(new IBnaSemesterDurationDtoValidator()); 

            RuleFor(p => p.BnaSemesterDurationId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
 