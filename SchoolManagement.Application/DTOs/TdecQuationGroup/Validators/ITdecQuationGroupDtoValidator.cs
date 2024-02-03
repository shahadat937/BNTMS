using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuationGroup.Validators
{
    public class ITdecQuationGroupDtoValidator : AbstractValidator<ITdecQuationGroupDto>
    {
        public ITdecQuationGroupDtoValidator()
        {
           RuleFor(c => c.BaseSchoolNameId)
               .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is greather than zero.");

        }
        
    }
}
