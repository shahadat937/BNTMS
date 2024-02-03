using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecActionStatus.Validators
{
    public class UpdateTdecActionStatusDtoValidator : AbstractValidator<TdecActionStatusDto>
    {
        public UpdateTdecActionStatusDtoValidator()
        {
            Include(new ITdecActionStatusDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
