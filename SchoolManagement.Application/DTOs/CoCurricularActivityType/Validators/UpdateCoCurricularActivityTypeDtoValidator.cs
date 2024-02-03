using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivityType.Validators
{
    public class UpdateCoCurricularActivityTypeDtoValidator : AbstractValidator<CoCurricularActivityTypeDto>
    {
        public UpdateCoCurricularActivityTypeDtoValidator()
        {
            Include(new ICoCurricularActivityTypeDtoValidator());

            RuleFor(p => p.CoCurricularActivityTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
