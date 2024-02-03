using FluentValidation;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReadingMaterialTitle.Validators 
{
    public class IReadingMaterialTitleDtoValidator : AbstractValidator<IReadingMaterialTitleDto>
    {
        public IReadingMaterialTitleDtoValidator()
        {
            //RuleFor(p => p.)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            //RuleFor(p => p.ReadingMaterialTitleTypeId)
            //   .NotEmpty().WithMessage("{PropertyName} is required.")
            //   .NotNull();
        }
    }
}
