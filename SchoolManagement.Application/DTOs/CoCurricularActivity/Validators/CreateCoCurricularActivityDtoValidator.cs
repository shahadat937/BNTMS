using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivity.Validators
{
    public class CreateCoCurricularActivityDtoValidator : AbstractValidator<CreateCoCurricularActivityDto>
    {
        public CreateCoCurricularActivityDtoValidator()
        {
            Include(new ICoCurricularActivityDtoValidator());
        }
    }
}
