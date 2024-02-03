using FluentValidation;

namespace SchoolManagement.Application.DTOs.Notice.Validators
{ 
    public class INoticeDtoValidator: AbstractValidator<INoticeDto>
    {
        public INoticeDtoValidator()
        {
            RuleFor(b => b.NoticeDetails)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(4000).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
