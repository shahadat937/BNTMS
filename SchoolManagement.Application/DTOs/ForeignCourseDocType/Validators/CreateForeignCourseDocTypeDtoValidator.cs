using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseDocType.Validators
{
    public class CreateForeignCourseDocTypeDtoValidator : AbstractValidator<CreateForeignCourseDocTypeDto>
    {
        public CreateForeignCourseDocTypeDtoValidator()
        {
            Include(new IForeignCourseDocTypeDtoValidator());
        }
    }
}
