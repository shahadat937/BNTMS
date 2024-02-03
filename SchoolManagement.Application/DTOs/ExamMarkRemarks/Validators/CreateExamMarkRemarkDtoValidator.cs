
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamMarkRemarks.Validators
{
   public class CreateExamMarkRemarkDtoValidator : AbstractValidator<CreateExamMarkRemarkDto>
    {
        public CreateExamMarkRemarkDtoValidator()
        {
            Include(new IExamMarkRemarkDtoValidator());
        }
    }
}
