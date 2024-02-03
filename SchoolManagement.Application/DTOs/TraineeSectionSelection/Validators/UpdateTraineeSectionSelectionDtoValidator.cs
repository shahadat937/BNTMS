using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeSectionSelection.Validators
{
    public class UpdateTraineeSectionSelectionDtoValidator : AbstractValidator<TraineeSectionSelectionDto>
    {
        public UpdateTraineeSectionSelectionDtoValidator() 
        {
            Include(new ITraineeSectionSelectionDtoValidator());

            //RuleFor(p => p.BnaBatchId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaClassSectionSelectionId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.TraineeId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSemesterId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
