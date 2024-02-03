using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectTypes.Validators
{
    public class CreateSubjectTypeDtoValidator : AbstractValidator<CreateSubjectTypeDto> 
    {
        public CreateSubjectTypeDtoValidator()
        {
            Include(new ISubjectTypeDtoValidator());
        }
    }
}
