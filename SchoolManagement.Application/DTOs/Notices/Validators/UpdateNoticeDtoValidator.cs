using FluentValidation;

namespace SchoolManagement.Application.DTOs.Notice.Validators
{
    public class UpdateNoticeDtoValidator : AbstractValidator<NoticeDto>
    {
        public UpdateNoticeDtoValidator()
        {
            Include(new INoticeDtoValidator()); 

            RuleFor(b => b.NoticeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 