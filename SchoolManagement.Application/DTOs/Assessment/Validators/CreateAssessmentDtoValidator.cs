
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Assessment.Validators
{
   public class CreateAssessmentDtoValidator : AbstractValidator<CreateAssessmentDto>
    {
        public CreateAssessmentDtoValidator()
        {
            Include(new IAssessmentDtoValidator());
        }
    }
}
