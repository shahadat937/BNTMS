using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ParentRelative.Validators
{
    public class UpdateParentRelativeDtoValidator : AbstractValidator<ParentRelativeDto>
    {
        public UpdateParentRelativeDtoValidator()
        {
            Include(new IParentRelativeDtoValidator());

            RuleFor(p => p.ParentRelativeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
