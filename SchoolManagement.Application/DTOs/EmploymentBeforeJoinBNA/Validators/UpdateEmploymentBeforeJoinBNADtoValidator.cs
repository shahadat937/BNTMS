using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna.Validators
{
    public class UpdateEmploymentBeforeJoinBnaDtoValidator : AbstractValidator<EmploymentBeforeJoinBnaDto>
    {
        public UpdateEmploymentBeforeJoinBnaDtoValidator()
        {
            Include(new IEmploymentBeforeJoinBnaDtoValidator());

            RuleFor(p => p.EmploymentBeforeJoinBnaId).NotNull().WithMessage("{PropertyName} must be present");

            //RuleFor(p => p.MembershipTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
