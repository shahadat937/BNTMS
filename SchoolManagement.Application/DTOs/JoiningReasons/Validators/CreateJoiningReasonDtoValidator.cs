using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.JoiningReasons.Validators
{
    public class CreateJoiningReasonDtoValidator:AbstractValidator<CreateJoiningReasonDto>
    {
        public CreateJoiningReasonDtoValidator() 
        { 
            Include(new IJoiningReasonDtoValidator());
        }
    }
}
