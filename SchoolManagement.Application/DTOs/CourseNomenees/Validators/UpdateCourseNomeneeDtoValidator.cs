using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.CourseNomenees.Validators
{ 
    public class UpdateCourseNomeneeDtoValidator : AbstractValidator<CourseNomeneeDto>
    {
        public UpdateCourseNomeneeDtoValidator()
        {
            Include(new ICourseNomeneeDtoValidator());

            RuleFor(b => b.CourseNomeneeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

