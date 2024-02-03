using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamPeriodTypes.Validators
{
    public class CreateExamPeriodTypeDtoValidator : AbstractValidator<CreateExamPeriodTypeDto>
    {
        public CreateExamPeriodTypeDtoValidator()  
        {
            Include(new IExamPeriodTypeDtoValidator()); 
        }
    }
} 
