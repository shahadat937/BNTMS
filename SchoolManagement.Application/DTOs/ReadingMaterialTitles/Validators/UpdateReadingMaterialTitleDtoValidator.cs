using FluentValidation;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReadingMaterialTitle.Validators 
{
    public class UpdateReadingMaterialTitleDtoValidator : AbstractValidator<ReadingMaterialTitleDto>
    {
        public UpdateReadingMaterialTitleDtoValidator()
        {
            Include(new IReadingMaterialTitleDtoValidator()); 

            RuleFor(p => p.ReadingMaterialTitleId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
