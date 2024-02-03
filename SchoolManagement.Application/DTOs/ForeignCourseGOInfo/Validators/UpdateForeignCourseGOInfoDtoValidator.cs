using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseGOInfo.Validators
{
    public class UpdateForeignCourseGOInfoDtoValidator : AbstractValidator<CreateForeignCourseGOInfoDto>
    {
        public UpdateForeignCourseGOInfoDtoValidator()
        {
            Include(new IForeignCourseGOInfoDtoValidator());

            RuleFor(c => c.DocumentName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
