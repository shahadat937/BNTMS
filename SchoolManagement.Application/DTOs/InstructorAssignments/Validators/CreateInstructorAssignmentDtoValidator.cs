
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InstructorAssignments.Validators
{ 
   public class CreateInstructorAssignmentDtoValidator : AbstractValidator<CreateInstructorAssignmentDto>
    {
        public CreateInstructorAssignmentDtoValidator()
        {
            Include(new IInstructorAssignmentDtoValidator());
        }
    }
}
