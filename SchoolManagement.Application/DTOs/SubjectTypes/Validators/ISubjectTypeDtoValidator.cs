
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectTypes.Validators
{
    public class ISubjectTypeDtoValidator : AbstractValidator<ISubjectTypeDto> 
    {
        public ISubjectTypeDtoValidator()
        {
            RuleFor(b => b.SubjectTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
