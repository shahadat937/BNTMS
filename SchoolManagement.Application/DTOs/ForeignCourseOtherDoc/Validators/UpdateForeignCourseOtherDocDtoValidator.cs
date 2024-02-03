using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.Validators
{
    public class UpdateForeignCourseOtherDocDtoValidator : AbstractValidator<ForeignCourseOtherDocDto>
    {
        public UpdateForeignCourseOtherDocDtoValidator()
        {
            Include(new IForeignCourseOtherDocDtoValidator());

            //RuleFor(c => c.ForeignCourseOtherDocName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
