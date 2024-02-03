using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.Validators
{
    public class UpdateGuestSpeakerQuationGroupDtoValidator : AbstractValidator<GuestSpeakerQuationGroupDto>
    {
        public UpdateGuestSpeakerQuationGroupDtoValidator()
        {
            Include(new IGuestSpeakerQuationGroupDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
