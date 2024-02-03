
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseDocType.Validators
{
   public class CreateInterServiceCourseDocTypeDtoValidator : AbstractValidator<CreateInterServiceCourseDocTypeDto>
    {
        public CreateInterServiceCourseDocTypeDtoValidator()
        {
            Include(new IInterServiceCourseDocTypeDtoValidator());
        }
    }
}
