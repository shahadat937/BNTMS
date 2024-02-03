
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HairColor.Validators
{
   public class CreateHairColorDtoValidator : AbstractValidator<CreateHairColorDto>
    {
        public CreateHairColorDtoValidator()
        {
            Include(new IHairColorDtoValidator());
        }
    }
}
