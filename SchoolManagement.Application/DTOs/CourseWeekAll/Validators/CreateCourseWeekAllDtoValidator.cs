﻿using FluentValidation;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.DTOs.CourseWeeks.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.CourseWeekAll.Validators
{
    public class CreateCourseWeekAllDtoValidator : AbstractValidator<CreateCourseWeekAllDto>
    {
        public CreateCourseWeekAllDtoValidator()
        {
            Include(new ICourseWeekAllDtoValidator());
        }
    }
}
