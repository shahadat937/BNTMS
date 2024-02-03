using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EducationalQualification.Validators
{
    public class CreateEducationalQualificationDtoValidator : AbstractValidator<CreateEducationalQualificationDto>
    {
        public CreateEducationalQualificationDtoValidator()
        {
            Include(new IEducationalQualificationDtoValidator());
        }
    }
}
