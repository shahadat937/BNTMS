using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands
{
    public class DeleteBnaExamAttendanceCommand : IRequest
    {
        public int BnaExamAttendanceId { get; set; }
    }
}
 