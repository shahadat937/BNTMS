using FluentValidation;

namespace SchoolManagement.Application.DTOs.IndividualNotices.Validators
{
    public class CreateIndividualNoticeDtoValidator : AbstractValidator<CreateIndividualNoticeDto>
    {
        public CreateIndividualNoticeDtoValidator()
        {
            Include(new IIndividualNoticeDtoValidator());
        }
    }
}
  