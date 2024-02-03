
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoursePlan.Validators
{
   public class CreateCoursePlanDtoValidator : AbstractValidator<CreateCoursePlanDto>
    {
        public CreateCoursePlanDtoValidator()
        { 
            Include(new ICoursePlanDtoValidator());
        }
    }
}
