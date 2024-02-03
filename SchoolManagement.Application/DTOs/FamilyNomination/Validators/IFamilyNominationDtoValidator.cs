using FluentValidation;

namespace SchoolManagement.Application.DTOs.FamilyNomination.Validators
{
    public class IFamilyNominationDtoValidator : AbstractValidator<IFamilyNominationDto>
    {
        public IFamilyNominationDtoValidator()
        {
            //RuleFor(p => p.TraineeId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            //RuleFor(p => p.FamilyNominationId)
            //   .NotEmpty().WithMessage("{PropertyName} is required.")
            //   .NotNull();
        }
    }
}
