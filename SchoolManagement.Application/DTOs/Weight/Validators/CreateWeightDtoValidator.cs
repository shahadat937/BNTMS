using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Weight.Validators
{
    public class CreateWeightDtoValidator:AbstractValidator<CreateWeightDto>
    {
        public CreateWeightDtoValidator()
        {
            Include(new IWeightDtoValidator());
        }
    }
}
