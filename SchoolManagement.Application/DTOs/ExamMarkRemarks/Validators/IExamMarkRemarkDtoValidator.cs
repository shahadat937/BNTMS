using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamMarkRemarks.Validators
{
    public class IExamMarkRemarkDtoValidator : AbstractValidator<IExamMarkRemarkDto>
    {
        public IExamMarkRemarkDtoValidator()
        {
            RuleFor(c => c.MarkRemark)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
