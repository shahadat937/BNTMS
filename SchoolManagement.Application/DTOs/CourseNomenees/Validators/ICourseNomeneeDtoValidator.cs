using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.CourseNomenees.Validators
{
    public class ICourseNomeneeDtoValidator : AbstractValidator<ICourseNomeneeDto>
    {
        public ICourseNomeneeDtoValidator() 
        {
            //RuleFor(b => b.CourseNomeneeName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
