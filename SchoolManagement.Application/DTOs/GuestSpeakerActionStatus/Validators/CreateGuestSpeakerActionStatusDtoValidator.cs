
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerActionStatus.Validators
{
   public class CreateGuestSpeakerActionStatusDtoValidator : AbstractValidator<CreateGuestSpeakerActionStatusDto>
    {
        public CreateGuestSpeakerActionStatusDtoValidator()
        {
            Include(new IGuestSpeakerActionStatusDtoValidator());
        }
    }
}
