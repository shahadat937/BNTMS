using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassSectionSelection.Validators
{ 
    public class UpdateBnaClassSectionSelectionDtoValidator : AbstractValidator<BnaClassSectionSelectionDto>
    {
        public UpdateBnaClassSectionSelectionDtoValidator()
        {
            Include(new IBnaClassSectionSelectionDtoValidator());

            RuleFor(p => p.BnaClassSectionSelectionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
