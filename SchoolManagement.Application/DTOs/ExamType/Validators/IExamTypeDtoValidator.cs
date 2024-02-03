using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamType.Validators
{
    public class IExamTypeDtoValidator : AbstractValidator<IExamTypeDto>
    {
        public IExamTypeDtoValidator()
        {
            RuleFor(c => c.ExamTypeName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
