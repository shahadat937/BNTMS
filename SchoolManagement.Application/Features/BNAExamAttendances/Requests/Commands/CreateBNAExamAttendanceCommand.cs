using SchoolManagement.Application.DTOs.BnaExamAttendance;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands
{
    public class CreateBnaExamAttendanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaExamAttendanceDto BnaExamAttendanceDto { get; set; }

    }
}
 