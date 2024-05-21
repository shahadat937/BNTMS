using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.UniversityCourseResult.Validators
{
    public class CreateUniversityCourseResultDtoValidator : AbstractValidator<CreateUniversityCourseResultDto>
    {
        public CreateUniversityCourseResultDtoValidator()
        {
            Include(new IUniversityCourseResultDtoValidator());
        }
    }
}
