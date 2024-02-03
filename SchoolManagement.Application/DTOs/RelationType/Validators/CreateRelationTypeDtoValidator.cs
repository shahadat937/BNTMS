using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.RelationType.Validators
{
    public class CreateRelationTypeDtoValidator : AbstractValidator<CreateRelationTypeDto>
    {
        public CreateRelationTypeDtoValidator()
        {
            Include(new IRelationTypeDtoValidator());
        }
    }
}
