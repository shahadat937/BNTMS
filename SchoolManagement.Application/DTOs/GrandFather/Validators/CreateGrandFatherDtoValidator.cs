using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GrandFather.Validators
{
    public class CreateGrandFatherDtoValidator : AbstractValidator<CreateGrandFatherDto>
    {
        public CreateGrandFatherDtoValidator()
        {
            Include(new IGrandFatherDtoValidator());
        }
    }
}
