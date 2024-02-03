
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectCategorys.Validators  
{
    public class ISubjectCategoryDtoValidator : AbstractValidator<ISubjectCategoryDto>
    {
        public ISubjectCategoryDtoValidator()
        {
            RuleFor(b => b.SubjectCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
