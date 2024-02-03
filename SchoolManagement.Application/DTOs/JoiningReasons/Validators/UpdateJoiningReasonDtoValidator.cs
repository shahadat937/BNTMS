using FluentValidation;
using SchoolManagement.Application.DTOs.JoiningReasons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.JoiningReasons.Validators
{
    public class UpdateJoiningReasonDtoValidator : AbstractValidator<JoiningReasonDto>
    {
        public UpdateJoiningReasonDtoValidator()
        {
            Include(new IJoiningReasonDtoValidator()); 

            RuleFor(p => p.JoiningReasonId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
