using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassSectionSelection.Validators
{
    public class CreateBnaClassSectionSelectionDtoValidator : AbstractValidator<CreateBnaClassSectionSelectionDto>
    {
        public CreateBnaClassSectionSelectionDtoValidator()  
        {
            Include(new IBnaClassSectionSelectionDtoValidator()); 
        }
    }
}  
