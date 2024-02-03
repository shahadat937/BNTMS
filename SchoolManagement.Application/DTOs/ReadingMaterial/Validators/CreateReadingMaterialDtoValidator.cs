using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ReadingMaterial.Validators
{
    public class CreateReadingMaterialDtoValidator : AbstractValidator<CreateReadingMaterialDto>
    {
        public CreateReadingMaterialDtoValidator()
        {
            Include(new IReadingMaterialDtoValidator());
        }
    }
}
