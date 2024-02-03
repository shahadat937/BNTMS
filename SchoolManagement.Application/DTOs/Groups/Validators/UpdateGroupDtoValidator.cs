using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Groups.Validators
{
    public class UpdateGroupDtoValidator : AbstractValidator<GroupDto>
    {
        public UpdateGroupDtoValidator()
        {
            Include(new IGroupDtoValidator());

            RuleFor(p => p.GroupId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
