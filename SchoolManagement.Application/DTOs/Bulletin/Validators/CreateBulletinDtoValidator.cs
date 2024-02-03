using FluentValidation;

namespace SchoolManagement.Application.DTOs.Bulletin.Validators
{
    public class CreateBulletinDtoValidator : AbstractValidator<CreateBulletinDto>
    {
        public CreateBulletinDtoValidator()
        {
            Include(new IBulletinDtoValidator());
        }
    }
}
 