
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.QuestionType.Validators
{
    public class IQuestionTypeDtoValidator : AbstractValidator<IQuestionTypeDto>
    {
        public IQuestionTypeDtoValidator()
        {
            RuleFor(b => b.Question)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
