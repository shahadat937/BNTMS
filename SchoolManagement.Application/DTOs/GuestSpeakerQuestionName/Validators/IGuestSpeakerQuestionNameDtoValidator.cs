using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuestionName.Validators
{
    public class IGuestSpeakerQuestionNameDtoValidator : AbstractValidator<IGuestSpeakerQuestionNameDto>
    {
        public IGuestSpeakerQuestionNameDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
