using FluentValidation;
using SchoolManagement.Application.DTOs.CourseNomenees;

namespace SchoolManagement.Application.DTOs.CourseNomenees.Validators
{
    public class CreateCourseNomeneeDtoValidator : AbstractValidator<ModifiedCreateCourseNomeneeDto>
    {
        public CreateCourseNomeneeDtoValidator()  
        {
            Include(new ICourseNomeneeDtoValidator()); 
        }
    }
}
