using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Nationality.Validators
{
    public class CreateNationalityDtoValidator : AbstractValidator<CreateNationalityDto>
    {
        public CreateNationalityDtoValidator()
        {
            Include(new INationalityDtoValidator());
        }
    }
}
