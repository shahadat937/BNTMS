using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerCategory.Validators
{
    public class UpdateUtofficerCategoryDtoValidator : AbstractValidator<UtofficerCategoryDto>
    {
        public UpdateUtofficerCategoryDtoValidator()
        {
            Include(new IUtofficerCategoryDtoValidator());

            RuleFor(p => p.UtofficerCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
