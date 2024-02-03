using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMedias.Validators
{
    public class CreateSocialMediaDtoValidator:AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaDtoValidator() 
        { 
            Include(new ISocialMediaDtoValidator());
        }
    }
}
