
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamType.Validators
{
   public class CreateExamTypeDtoValidator : AbstractValidator<CreateExamTypeDto>
    {
        public CreateExamTypeDtoValidator()
        {
            Include(new IExamTypeDtoValidator());
        }
    }
}
