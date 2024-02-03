using FluentValidation;

namespace SchoolManagement.Application.DTOs.IndividualNotices.Validators
{  
    public class IIndividualNoticeDtoValidator: AbstractValidator<IIndividualNoticeDto>
    {
        public IIndividualNoticeDtoValidator()
        {
            //RuleFor(b => b.NoticeDetails) 
            //    .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
