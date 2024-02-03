
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForceType.Validators
{
   public class CreateForceTypeDtoValidator : AbstractValidator<CreateForceTypeDto>
    {
        public CreateForceTypeDtoValidator()
        {
            Include(new IForceTypeDtoValidator());
        }
    }
}
