using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.CourseInstructors.Validators
{
    public class ICourseInstructorDtoValidator : AbstractValidator<ICourseInstructorDto>
    {
        public ICourseInstructorDtoValidator() 
        {
            //RuleFor(b => b.CourseInstructorName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
