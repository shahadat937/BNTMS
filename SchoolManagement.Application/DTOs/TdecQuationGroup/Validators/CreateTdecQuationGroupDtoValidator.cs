
using FluentValidation;
using SchoolManagement.Application.DTOs.TdecQuationGroup.CreateTdecQuationGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuationGroup.Validators
{
   public class CreateTdecQuationGroupDtoValidator : AbstractValidator<CreateTdecQuationGroupDto>
    {
        public CreateTdecQuationGroupDtoValidator()
        {
            Include(new ITdecQuationGroupDtoValidator());
        }
    }
}
