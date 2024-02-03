using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeCourseStatus.Validators
{
    public class UpdateTraineeCourseStatusDtoValidator : AbstractValidator<TraineeCourseStatusDto>
    {
        public UpdateTraineeCourseStatusDtoValidator()
        {
            Include(new ITraineeCourseStatusDtoValidator());

            RuleFor(p => p.TraineeCourseStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
