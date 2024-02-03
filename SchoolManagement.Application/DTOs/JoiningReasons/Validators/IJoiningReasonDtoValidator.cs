using FluentValidation;
using SchoolManagement.Application.DTOs.JoiningReasons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.JoiningReasons.Validators
{
    public class IJoiningReasonDtoValidator : AbstractValidator<IJoiningReasonDto>
    {
        public IJoiningReasonDtoValidator()
        {

            RuleFor(p => p.ReasonTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.TraineeId)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();
        }
    }
}
