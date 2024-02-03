
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseTask.Validators
{
   public class CreateCourseTaskDtoValidator : AbstractValidator<CreateCourseTaskDto>
    {
        public CreateCourseTaskDtoValidator()
        {
            Include(new ICourseTaskDtoValidator());
        }
    }
}
