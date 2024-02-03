using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuationGroup.Validators
{
    public class UpdateTdecQuationGroupDtoValidator : AbstractValidator<TdecQuationGroupDto>
    {
        public UpdateTdecQuationGroupDtoValidator()
        {
            Include(new ITdecQuationGroupDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
