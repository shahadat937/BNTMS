using FluentValidation;
using SchoolManagement.Application.DTOs.CourseWeekAll.Validators;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BnaClassPeriod.Validators
{
    public class CreateBnaClassPeriodDtoValidator : AbstractValidator<CreateBnaClassPeriodDto>
    {
        public CreateBnaClassPeriodDtoValidator()
        {
            Include(new IBnaClassPeriodDtoValidator());
        }
    }
}