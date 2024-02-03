using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseTypes.Validators
{
    public class CreateCourseTypeDtoValidator : AbstractValidator<CreateCourseTypeDto>
    {
        public CreateCourseTypeDtoValidator()  
        {
            Include(new ICourseTypeDtoValidator()); 
        }
    }
}
