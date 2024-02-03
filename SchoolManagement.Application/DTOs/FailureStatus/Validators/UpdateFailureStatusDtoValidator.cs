using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.FailureStatus.Validators
{
    
    public class UpdateFailureStatusDtoValidator : AbstractValidator<FailureStatusDto>
        {
        public UpdateFailureStatusDtoValidator()
        {
            Include(new IFailureStatusDtoValidator());

            RuleFor(p => p.FailureStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
