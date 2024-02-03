
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseGOInfo.Validators
{
   public class CreateForeignCourseGOInfoDtoValidator : AbstractValidator<CreateForeignCourseGOInfoDto>
    {
        public CreateForeignCourseGOInfoDtoValidator()
        {
            Include(new IForeignCourseGOInfoDtoValidator());
        }
    }
}
