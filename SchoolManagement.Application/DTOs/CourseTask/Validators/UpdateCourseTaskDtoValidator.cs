using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseTask.Validators
{
    public class UpdateCourseTaskDtoValidator : AbstractValidator<CourseTaskDto>
    {
        public UpdateCourseTaskDtoValidator()
        {
            Include(new ICourseTaskDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
