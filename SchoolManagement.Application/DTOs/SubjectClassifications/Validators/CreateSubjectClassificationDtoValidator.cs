using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SubjectClassifications.Validators 
{
    public class CreateSubjectClassificationDtoValidator : AbstractValidator<CreateSubjectClassificationDto>
    {
        public CreateSubjectClassificationDtoValidator()
        {
            Include(new ISubjectClassificationDtoValidator());
        }
    }
}
