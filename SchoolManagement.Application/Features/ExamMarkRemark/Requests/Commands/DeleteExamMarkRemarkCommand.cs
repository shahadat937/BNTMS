using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands
{
    public class DeleteExamMarkRemarkCommand : IRequest
    {
        public int ExamMarkRemarksId { get; set; }
    }
}
