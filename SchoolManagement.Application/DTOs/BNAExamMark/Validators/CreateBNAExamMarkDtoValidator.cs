using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamMark.Validators
{
    public class CreateBnaExamMarkDtoValidator : AbstractValidator<CreateBnaExamMarkDto>
    {
        public CreateBnaExamMarkDtoValidator()
        {
            Include(new IBnaExamMarkDtoValidator());
        }
    } 
} 
