using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeBioDataOther.Validators
{
    public class UpdateTraineeBioDataOtherDtoValidator : AbstractValidator<TraineeBioDataOtherDto>
    {
        public UpdateTraineeBioDataOtherDtoValidator()
        {
            Include(new ITraineeBioDataOtherDtoValidator());

            //RuleFor(p => p.DistrictId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.TraineeBioDataOtherId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
