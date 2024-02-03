using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaExamAttendance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Requests.Queries
{
    public class GetBnaExamAttendanceDetailRequest : IRequest<BnaExamAttendanceDto>
    {
        public int BnaExamAttendanceId { get; set; }
    }
}
 