using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ClassType.Validators
{
    public class UpdateClassTypeDtoValidator : AbstractValidator<ClassTypeDto>
    {
        public UpdateClassTypeDtoValidator()
        {
            Include(new IClassTypeDtoValidator());

            RuleFor(p => p.ClassTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
