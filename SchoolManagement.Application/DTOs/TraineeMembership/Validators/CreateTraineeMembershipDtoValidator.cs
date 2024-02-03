using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeMembership.Validators
{
    public class CreateTraineeMembershipDtoValidator : AbstractValidator<CreateTraineeMembershipDto>
    {
        public CreateTraineeMembershipDtoValidator()
        {
            Include(new ITraineeMembershipDtoValidator());
        }
    }
}
