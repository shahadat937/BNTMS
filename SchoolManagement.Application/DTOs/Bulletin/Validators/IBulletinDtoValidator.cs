using FluentValidation;

namespace SchoolManagement.Application.DTOs.Bulletin.Validators
{ 
    public class IBulletinDtoValidator: AbstractValidator<IBulletinDto>
    {
        public IBulletinDtoValidator()
        {
            RuleFor(b => b.BuletinDetails)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
