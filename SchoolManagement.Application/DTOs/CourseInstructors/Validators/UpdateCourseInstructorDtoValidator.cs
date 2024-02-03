using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.CourseInstructors.Validators
{ 
    public class UpdateCourseInstructorDtoValidator : AbstractValidator<CourseInstructorDto>
    {
        public UpdateCourseInstructorDtoValidator()
        {
            Include(new ICourseInstructorDtoValidator());

            RuleFor(b => b.CourseInstructorId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

