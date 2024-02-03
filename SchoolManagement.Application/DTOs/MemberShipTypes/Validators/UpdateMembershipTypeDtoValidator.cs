using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MembershipTypes.Validators
{
    public class UpdateMembershipTypeDtoValidator : AbstractValidator<MembershipTypeDto>
    { 
        public UpdateMembershipTypeDtoValidator()
        {
            Include(new IMembershipTypeDtoValidator());

            RuleFor(p => p.MembershipTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
