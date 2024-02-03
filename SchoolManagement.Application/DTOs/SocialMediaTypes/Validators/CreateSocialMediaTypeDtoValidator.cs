using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMediaTypes.Validators
{
    public class CreateSocialMediaTypeDtoValidator:AbstractValidator<CreateSocialMediaTypeDto>
    {
        public CreateSocialMediaTypeDtoValidator() 
        { 
            Include(new ISocialMediaTypeDtoValidator());
        }
    }
}
 