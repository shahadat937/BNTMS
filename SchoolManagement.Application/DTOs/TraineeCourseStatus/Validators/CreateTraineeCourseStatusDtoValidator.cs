using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeCourseStatus.Validators
{
    public class CreateTraineeCourseStatusDtoValidator:AbstractValidator<CreateTraineeCourseStatusDto>
    {
        public CreateTraineeCourseStatusDtoValidator()
        {
            Include(new ITraineeCourseStatusDtoValidator());
        }
    }
}
