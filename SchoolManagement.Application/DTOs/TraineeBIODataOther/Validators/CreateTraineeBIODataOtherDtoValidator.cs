using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeBioDataOther.Validators
{
    public class CreateTraineeBioDataOtherDtoValidator : AbstractValidator<CreateTraineeBioDataOtherDto>
    {
        public CreateTraineeBioDataOtherDtoValidator()
        {
            Include(new ITraineeBioDataOtherDtoValidator());
        }
    }
}
