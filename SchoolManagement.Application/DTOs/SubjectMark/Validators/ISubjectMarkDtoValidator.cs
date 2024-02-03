
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SubjectMark.Validators
{
    public class ISubjectMarkDtoValidator : AbstractValidator<ISubjectMarkDto> 
    {
        public ISubjectMarkDtoValidator()
        {
            //RuleFor(b => b.SubjectMarkName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
