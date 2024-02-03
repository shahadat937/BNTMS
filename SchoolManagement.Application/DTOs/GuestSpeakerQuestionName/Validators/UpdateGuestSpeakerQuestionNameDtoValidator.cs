using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GuestSpeakerQuestionName.Validators
{
    public class UpdateGuestSpeakerQuestionNameDtoValidator : AbstractValidator<GuestSpeakerQuestionNameDto>
    {
        public UpdateGuestSpeakerQuestionNameDtoValidator()
        {
            Include(new IGuestSpeakerQuestionNameDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
