using FluentValidation;

namespace SchoolManagement.Application.DTOs.IndividualBulletins.Validators
{
    public class CreateIndividualBulletinDtoValidator : AbstractValidator<CreateIndividualBulletinDto>
    {
        public CreateIndividualBulletinDtoValidator()
        {
            Include(new IIndividualBulletinDtoValidator());
        }
    }
}
  