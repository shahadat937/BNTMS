using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Electeds.Validators
{
    public class CreateElectedDtoValidator:AbstractValidator<CreateElectedDto>
    {
        public CreateElectedDtoValidator()  
        { 
            Include(new IElectedDtoValidator());
        }
    }
}
