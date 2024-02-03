using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMediaTypes.Validators
{
    public class UpdateSocialMediaTypeDtoValidator : AbstractValidator<SocialMediaTypeDto>
    {
        public UpdateSocialMediaTypeDtoValidator()
        {
            Include(new ISocialMediaTypeDtoValidator()); 

            RuleFor(p => p.SocialMediaTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
