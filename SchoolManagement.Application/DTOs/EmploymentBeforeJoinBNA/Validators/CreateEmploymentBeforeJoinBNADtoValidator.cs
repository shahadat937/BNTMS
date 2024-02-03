using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna.Validators
{
    public class CreateEmploymentBeforeJoinBnaDtoValidator : AbstractValidator<CreateEmploymentBeforeJoinBnaDto>
    {
        public CreateEmploymentBeforeJoinBnaDtoValidator()
        {
            Include(new IEmploymentBeforeJoinBnaDtoValidator());
        }
    }
}
