using FluentValidation;

namespace SchoolManagement.Application.DTOs.IndividualBulletins.Validators
{  
    public class IIndividualBulletinDtoValidator: AbstractValidator<IIndividualBulletinDto>
    {
        public IIndividualBulletinDtoValidator()
        {
            //RuleFor(b => b.NoticeDetails) 
            //    .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
