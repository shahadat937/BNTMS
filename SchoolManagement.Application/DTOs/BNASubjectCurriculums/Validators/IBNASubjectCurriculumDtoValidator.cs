
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSubjectCurriculums.Validators
{
    public class IBnaSubjectCurriculumDtoValidator : AbstractValidator<IBnaSubjectCurriculumDto>
    {
        public IBnaSubjectCurriculumDtoValidator()
        {
            RuleFor(b => b.SubjectCurriculumName)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
