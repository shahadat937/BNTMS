using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InstructorAssignments.Validators
{ 
    public class IInstructorAssignmentDtoValidator : AbstractValidator<IInstructorAssignmentDto>
    {
        public IInstructorAssignmentDtoValidator()
        {
            //RuleFor(c => c.InstructorAssignmentName)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
