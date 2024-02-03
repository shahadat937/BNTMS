using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AssignmentMarkEntry.Validators
{
    public class IAssignmentMarkEntryDtoValidator : AbstractValidator<IAssignmentMarkEntryDto>
    {
        public IAssignmentMarkEntryDtoValidator() 
        {
            //RuleFor(b => b.AssignmentMarkEntryName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
