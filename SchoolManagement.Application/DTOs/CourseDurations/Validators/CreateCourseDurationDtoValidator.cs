using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseDurations.Validators
{
    public class CreateCourseDurationDtoValidator : AbstractValidator<CreateCourseDurationDto>
    {
        public CreateCourseDurationDtoValidator()
        {
            Include(new ICourseDurationDtoValidator());
        }
    }
}
