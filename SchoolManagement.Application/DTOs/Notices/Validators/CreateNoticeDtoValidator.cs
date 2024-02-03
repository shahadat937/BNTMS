using FluentValidation;

namespace SchoolManagement.Application.DTOs.Notice.Validators
{
    public class CreateNoticeDtoValidator : AbstractValidator<CreateNoticeDto>
    {
        public CreateNoticeDtoValidator()
        {
            Include(new INoticeDtoValidator());
        }
    }
}
 