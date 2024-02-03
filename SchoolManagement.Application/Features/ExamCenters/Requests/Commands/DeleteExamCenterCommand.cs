using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenters.Requests.Commands
{
    public class DeleteExamCenterCommand : IRequest
    {
        public int ExamCenterId { get; set; }
    }
}
 