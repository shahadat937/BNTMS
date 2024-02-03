using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NewEntryEvaluation.Validators
{
    public class INewEntryEvaluationDtoValidator : AbstractValidator<INewEntryEvaluationDto>
    {
        public INewEntryEvaluationDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
