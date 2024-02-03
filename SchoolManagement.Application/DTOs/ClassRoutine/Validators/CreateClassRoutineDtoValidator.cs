using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ClassRoutine.Validators
{
    public class CreateClassRoutineDtoValidator : AbstractValidator<CreateClassRoutineDto>
    {
        public CreateClassRoutineDtoValidator()
        {
            Include(new IClassRoutineDtoValidator());
        }
    }
}
