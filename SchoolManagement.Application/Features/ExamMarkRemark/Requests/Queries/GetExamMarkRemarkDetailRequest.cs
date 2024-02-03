using MediatR;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries
{
    public class GetExamMarkRemarkDetailRequest : IRequest<ExamMarkRemarkDto>
    {
        public int ExamMarkRemarksId { get; set; }
    }
}
