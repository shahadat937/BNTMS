using FluentValidation;
using SchoolManagement.Application.DTOs.IndividualNotice;

namespace SchoolManagement.Application.DTOs.IndividualNotices.Validators
{ 
    public class UpdateIndividualNoticeDtoValidator : AbstractValidator<IndividualNoticeDto>
    {
        public UpdateIndividualNoticeDtoValidator()
        {
            Include(new IIndividualNoticeDtoValidator()); 

            RuleFor(b => b.IndividualNoticeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 