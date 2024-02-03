using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseModule.Validators
{
    public class CreateCourseModuleDtoValidator : AbstractValidator<CreateCourseModuleDto>
    {
        public CreateCourseModuleDtoValidator()
        {
            Include(new ICourseModuleDtoValidator());
        }
    }
}
