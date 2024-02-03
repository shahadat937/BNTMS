using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerType.Validators
{
    public class CreateUtofficerTypeDtoValidator : AbstractValidator<CreateUtofficerTypeDto>
    {
        public CreateUtofficerTypeDtoValidator()
        {
            Include(new IUtofficerTypeDtoValidator());
        }
    }
}
