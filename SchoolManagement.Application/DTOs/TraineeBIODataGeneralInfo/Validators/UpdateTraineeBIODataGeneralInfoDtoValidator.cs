using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo.Validators
{
    public class UpdateTraineeBioDataGeneralInfoDtoValidator : AbstractValidator<CreateTraineeBioDataGeneralInfoDto>
    {
        public UpdateTraineeBioDataGeneralInfoDtoValidator()
        {
            Include(new ITraineeBioDataGeneralInfoDtoValidator());

            //RuleFor(p => p.DistrictId).NotNull().WithMessage("{PropertyName} must be present");

            //RuleFor(p => p.TraineeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
