using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeSectionSelection.Validators
{
    public class CreateTraineeSectionSelectionDtoValidator : AbstractValidator<CreateTraineeSectionSelectionDto>
    {
        public CreateTraineeSectionSelectionDtoValidator()
        {
            Include(new ITraineeSectionSelectionDtoValidator());
        }
    }
}
