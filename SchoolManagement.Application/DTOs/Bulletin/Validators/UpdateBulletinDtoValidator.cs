using FluentValidation;

namespace SchoolManagement.Application.DTOs.Bulletin.Validators
{
    public class UpdateBulletinDtoValidator : AbstractValidator<BulletinDto>
    {
        public UpdateBulletinDtoValidator()
        {
            Include(new IBulletinDtoValidator()); 

            RuleFor(b => b.BulletinId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 