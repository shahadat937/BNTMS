using FluentValidation;

namespace SchoolManagement.Application.DTOs.FamilyNomination.Validators
{
    public class CreateFamilyNominationDtoValidator:AbstractValidator<CreateFamilyNominationDto>
    {
        public CreateFamilyNominationDtoValidator() 
        { 
            Include(new IFamilyNominationDtoValidator());
        }
    }
}
