using SchoolManagement.Application.DTOs.BnaExamAttendance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands
{
    public class UpdateBnaExamAttendanceCommand : IRequest<Unit>
    {
        public BnaExamAttendanceDto BnaExamAttendanceDto { get; set; }

    }
}
 