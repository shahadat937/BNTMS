using FluentValidation;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReadingMaterialTitles.Validators 
{
    public class CreateReadingMaterialTitleDtoValidator:AbstractValidator<CreateReadingMaterialTitleDto>
    {
        public CreateReadingMaterialTitleDtoValidator() 
        { 
            Include(new IReadingMaterialTitleDtoValidator());
        }
    }
}
