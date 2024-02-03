using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo.Validators
{
    public class CreateTraineeBioDataGeneralInfoDtoValidator : AbstractValidator<CreateTraineeBioDataGeneralInfoDto>
    {
        public CreateTraineeBioDataGeneralInfoDtoValidator()
        {
            Include(new ITraineeBioDataGeneralInfoDtoValidator());
        }
    }
}
