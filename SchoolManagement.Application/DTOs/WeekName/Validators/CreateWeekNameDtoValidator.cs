
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.WeekName.Validators
{
   public class CreateWeekNameDtoValidator : AbstractValidator<CreateWeekNameDto>
    {
        public CreateWeekNameDtoValidator()
        {
            Include(new IWeekNameDtoValidator());
        }
    }
}
