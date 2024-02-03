using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AssignmentMarkEntry.Validators
{
    public class UpdateAssignmentMarkEntryDtoValidator : AbstractValidator<AssignmentMarkEntryDto>
    {
        public UpdateAssignmentMarkEntryDtoValidator()
        {
            Include(new IAssignmentMarkEntryDtoValidator());

            RuleFor(b => b.AssignmentMarkEntryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

