﻿
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DefenseType.Validators
{
   public class CreateDefenseTypeDtoValidator : AbstractValidator<CreateDefenseTypeDto>
    {
        public CreateDefenseTypeDtoValidator()
        {
            Include(new IDefenseTypeDtoValidator());
        }
    }
}
