using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Instructor.Validators
{
    public class InstructorDtoValidator : AbstractValidator<InstructorDto>
    {
        public InstructorDtoValidator()
        {
            Include(new IInstructorDtoValidator());
        }
    }
}
