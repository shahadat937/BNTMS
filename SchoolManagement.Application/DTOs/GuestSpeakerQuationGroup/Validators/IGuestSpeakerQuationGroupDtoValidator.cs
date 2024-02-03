using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.Validators
{
    public class IGuestSpeakerQuationGroupDtoValidator : AbstractValidator<IGuestSpeakerQuationGroupDto>
    {
        public IGuestSpeakerQuationGroupDtoValidator()
        {
           RuleFor(c => c.BaseSchoolNameId)
               .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is greather than zero.");

        }
        
    }
}
