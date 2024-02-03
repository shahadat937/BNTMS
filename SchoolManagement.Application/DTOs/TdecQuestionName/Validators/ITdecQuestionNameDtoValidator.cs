using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuestionName.Validators
{
    public class ITdecQuestionNameDtoValidator : AbstractValidator<ITdecQuestionNameDto>
    {
        public ITdecQuestionNameDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
