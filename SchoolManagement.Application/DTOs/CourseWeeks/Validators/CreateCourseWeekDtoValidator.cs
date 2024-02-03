using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseWeeks.Validators
{
    public class CreateCourseWeekDtoValidator : AbstractValidator<CreateCourseWeekDto>
    {
        public CreateCourseWeekDtoValidator()  
        {
            Include(new ICourseWeekDtoValidator()); 
        }
    }
}
