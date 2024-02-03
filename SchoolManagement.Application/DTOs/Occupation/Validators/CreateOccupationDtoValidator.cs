
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Occupation.Validators
{
   public class CreateOccupationDtoValidator : AbstractValidator<CreateOccupationDto>
    {
        public CreateOccupationDtoValidator()
        {
            Include(new IOccupationDtoValidator());
        }
    }
}
