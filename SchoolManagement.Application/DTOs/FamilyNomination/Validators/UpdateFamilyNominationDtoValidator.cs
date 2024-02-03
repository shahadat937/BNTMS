using FluentValidation;

namespace SchoolManagement.Application.DTOs.FamilyNomination.Validators
{
    public class UpdateFamilyNominationDtoValidator : AbstractValidator<FamilyNominationDto>
    {
        public UpdateFamilyNominationDtoValidator()
        {
            Include(new IFamilyNominationDtoValidator()); 

            RuleFor(p => p.FamilyNominationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
