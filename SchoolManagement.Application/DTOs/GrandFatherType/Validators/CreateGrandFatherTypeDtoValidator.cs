using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.GrandFatherType.Validators
{
    public class CreateGrandFatherTypeDtoValidator : AbstractValidator<CreateGrandFatherTypeDto>
    {
        public CreateGrandFatherTypeDtoValidator()
        {
            Include(new IGrandFatherTypeDtoValidator());
        }
    }
}
