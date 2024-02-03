using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerCategory.Validators
{
    public class CreateUtofficerCategoryDtoValidator : AbstractValidator<CreateUtofficerCategoryDto>
    {
        public CreateUtofficerCategoryDtoValidator()
        {
            Include(new IUtofficerCategoryDtoValidator());
        }
    }
}
