using FluentValidation;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSubjectname.Validators
{
    public class CreateBnaSubjectNameDtoValidator:AbstractValidator<CreateBnaSubjectNameDto>
    { 
        public CreateBnaSubjectNameDtoValidator() 
        { 
            Include(new IBnaSubjectNameDtoValidator());
        }
    }
}
