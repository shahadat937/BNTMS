using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Height.Validators
{
    public class CreateHeightDtoValidator : AbstractValidator<CreateHeightDto>
    {
        public CreateHeightDtoValidator()
        {
            Include(new IHeightDtoValidator());
        }
    }
}
