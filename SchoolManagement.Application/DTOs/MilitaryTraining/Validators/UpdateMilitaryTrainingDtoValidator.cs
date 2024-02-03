using FluentValidation;

namespace SchoolManagement.Application.DTOs.MilitaryTraining.Validators
{
    public class UpdateMilitaryTrainingDtoValidator : AbstractValidator<MilitaryTrainingDto>
    {
        public UpdateMilitaryTrainingDtoValidator()
        {
            Include(new IMilitaryTrainingDtoValidator()); 

            RuleFor(p => p.MilitaryTrainingId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
