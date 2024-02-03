using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Gender.Validators
{
    public class CreateGenderDtoValidator : AbstractValidator<CreateGenderDto>
    {
        public CreateGenderDtoValidator()
        {
            Include(new IGenderDtoValidator());
        }
    }
}
