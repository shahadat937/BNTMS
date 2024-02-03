using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivityType.Validators
{
    public class CreateCoCurricularActivityTypeDtoValidator : AbstractValidator<CreateCoCurricularActivityTypeDto>
    {
        public CreateCoCurricularActivityTypeDtoValidator()
        {
            Include(new ICoCurricularActivityTypeDtoValidator());
        }
    }
}
