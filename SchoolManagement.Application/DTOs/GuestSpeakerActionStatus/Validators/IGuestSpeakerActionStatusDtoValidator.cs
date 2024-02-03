using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerActionStatus.Validators
{
    public class IGuestSpeakerActionStatusDtoValidator : AbstractValidator<IGuestSpeakerActionStatusDto>
    {
        public IGuestSpeakerActionStatusDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
