using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ClassType.Validators
{
    public class CreateClassTypeDtoValidator : AbstractValidator<CreateClassTypeDto>
    {
        public CreateClassTypeDtoValidator()
        {
            Include(new IClassTypeDtoValidator());
        }
    }
}
