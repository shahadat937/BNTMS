using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AssignmentMarkEntry.Validators
{
    public class CreateAssignmentMarkEntryDtoValidator : AbstractValidator<CreateAssignmentMarkEntryDto>
    {
        public CreateAssignmentMarkEntryDtoValidator()  
        {
            Include(new IAssignmentMarkEntryDtoValidator()); 
        }
    }
}
