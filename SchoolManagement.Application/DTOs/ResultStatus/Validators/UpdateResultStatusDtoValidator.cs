using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ResultStatus.Validators
{
    public class UpdateResultStatusDtoValidator : AbstractValidator<ResultStatusDto>
    {
        public UpdateResultStatusDtoValidator()
        {
            Include(new IResultStatusDtoValidator());

            RuleFor(p => p.ResultStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
