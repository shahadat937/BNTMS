using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseDurations.Validators
{ 
    
    public class UpdateCourseDurationDtoValidator : AbstractValidator<CourseDurationDto>
        {
        public UpdateCourseDurationDtoValidator()
        {
            //Include(new ICourseDurationDtoValidator());

            //RuleFor(p => p.CourseDurationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
