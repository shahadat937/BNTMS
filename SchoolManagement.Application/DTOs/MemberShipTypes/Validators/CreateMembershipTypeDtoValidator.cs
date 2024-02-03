using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MembershipTypes.Validators
{ 
    public class CreateMembershipTypeDtoValidator:AbstractValidator<CreateMembershipTypeDto>
    {
        public CreateMembershipTypeDtoValidator()
        {
            Include(new IMembershipTypeDtoValidator());
        }
    }
}
