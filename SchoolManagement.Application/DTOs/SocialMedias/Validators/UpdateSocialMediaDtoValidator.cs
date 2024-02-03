using FluentValidation;
using SchoolManagement.Application.DTOs.CodeValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMedias.Validators
{
    public class UpdateSocialMediaDtoValidator : AbstractValidator<SocialMediaDto>
    {
        public UpdateSocialMediaDtoValidator()
        {
            Include(new ISocialMediaDtoValidator()); 

            RuleFor(p => p.SocialMediaId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
