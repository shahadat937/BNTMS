
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.Validators
{
   public class CreateForeignCourseOtherDocDtoValidator : AbstractValidator<CreateForeignCourseOtherDocDto>
    {
        public CreateForeignCourseOtherDocDtoValidator()
        {
            Include(new IForeignCourseOtherDocDtoValidator());
        }
    }
}
