
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuestionName.Validators
{
   public class CreateGuestSpeakerQuestionNameDtoValidator : AbstractValidator<CreateGuestSpeakerQuestionNameDto>
    {
        public CreateGuestSpeakerQuestionNameDtoValidator()
        {
            Include(new IGuestSpeakerQuestionNameDtoValidator());
        }
    }
}
