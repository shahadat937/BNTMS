using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerActionStatus.Validators
{
    public class UpdateGuestSpeakerActionStatusDtoValidator : AbstractValidator<GuestSpeakerActionStatusDto>
    {
        public UpdateGuestSpeakerActionStatusDtoValidator()
        {
            Include(new IGuestSpeakerActionStatusDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
