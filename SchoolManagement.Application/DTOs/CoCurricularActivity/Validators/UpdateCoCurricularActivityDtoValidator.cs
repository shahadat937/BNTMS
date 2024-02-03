using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivity.Validators
{
    public class UpdateCoCurricularActivityDtoValidator : AbstractValidator<CoCurricularActivityDto>
    {
        public UpdateCoCurricularActivityDtoValidator()
        {
            Include(new ICoCurricularActivityDtoValidator());

            RuleFor(p => p.CoCurricularActivityId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
