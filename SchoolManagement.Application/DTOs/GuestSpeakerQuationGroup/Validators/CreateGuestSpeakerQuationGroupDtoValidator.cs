
using FluentValidation;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.CreateGuestSpeakerQuationGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.Validators
{
   public class CreateGuestSpeakerQuationGroupDtoValidator : AbstractValidator<CreateGuestSpeakerQuationGroupDto>
    {
        public CreateGuestSpeakerQuationGroupDtoValidator()
        {
            Include(new IGuestSpeakerQuationGroupDtoValidator());
        }
    }
}
