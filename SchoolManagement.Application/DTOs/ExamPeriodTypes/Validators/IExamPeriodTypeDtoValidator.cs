using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ExamPeriodTypes.Validators
{
    public class IExamPeriodTypeDtoValidator : AbstractValidator<IExamPeriodTypeDto>
    {
        public IExamPeriodTypeDtoValidator() 
        {
            RuleFor(b => b.ExamPeriodName) 
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
