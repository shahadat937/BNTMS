using FluentValidation;
using SchoolManagement.Application.DTOs.IndividualBulletin;

namespace SchoolManagement.Application.DTOs.IndividualBulletins.Validators
{ 
    public class UpdateIndividualBulletinDtoValidator : AbstractValidator<IndividualBulletinDto>
    {
        public UpdateIndividualBulletinDtoValidator()
        {
            Include(new IIndividualBulletinDtoValidator()); 

            RuleFor(b => b.IndividualBulletinId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 