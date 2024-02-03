using FluentValidation;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.DTOs.BnaSubjectname.Validators
{
    public class IBnaSubjectNameDtoValidator : AbstractValidator<IBnaSubjectNameDto>
    { 
        public IBnaSubjectNameDtoValidator()
        {
            //RuleFor(p => p.BnaSemesterId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.SubjectCategoryId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.BnaSubjectCurriculumId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.CourseNameId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.SubjectTypeId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.KindOfSubjectId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.BaseSchoolNameId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.SubjectClassificationId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.SubjectName)
            //   .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

            //RuleFor(p => p.SubjectCode)
            //   .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
