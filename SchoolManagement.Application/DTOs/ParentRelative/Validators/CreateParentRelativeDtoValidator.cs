using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ParentRelative.Validators
{
    public class CreateParentRelativeDtoValidator : AbstractValidator<CreateParentRelativeDto>
    {
        public CreateParentRelativeDtoValidator()
        {
            Include(new IParentRelativeDtoValidator());
        }
    }
}
