using MediatR;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands
{
    public class UpdateExamMarkRemarkCommand : IRequest<Unit>
    {
        public ExamMarkRemarkDto ExamMarkRemarkDto { get; set; }
    }
}
