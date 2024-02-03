using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseInstructors.Validators
{
    public class CreateCourseInstructorDtoValidator : AbstractValidator<ModifiedCreateCourseInstructorDto>
    {
        public CreateCourseInstructorDtoValidator()  
        {
            Include(new ICourseInstructorDtoValidator()); 
        }
    }
}
