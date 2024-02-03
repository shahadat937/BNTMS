using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeMembership.Validators
{
    public class UpdateTraineeMembershipDtoValidator : AbstractValidator<TraineeMembershipDto>
    {
        public UpdateTraineeMembershipDtoValidator()
        {
            Include(new ITraineeMembershipDtoValidator());

            RuleFor(p => p.TraineeMembershipId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.MembershipTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
