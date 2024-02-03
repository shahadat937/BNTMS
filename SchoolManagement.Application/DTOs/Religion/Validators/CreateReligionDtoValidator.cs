﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Religion.Validators
{
    public class CreateReligionDtoValidator : AbstractValidator<CreateReligionDto>
    {
        public CreateReligionDtoValidator()
        {
            Include(new IReligionDtoValidator());
        }
    }
}
