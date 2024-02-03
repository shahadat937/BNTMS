using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamAttendance.Validators
{
    public class CreateBnaExamAttendanceDtoValidator : AbstractValidator<CreateBnaExamAttendanceDto>
    {
        public CreateBnaExamAttendanceDtoValidator()
        {
            Include(new IBnaExamAttendanceDtoValidator());
        }
    }
}
 