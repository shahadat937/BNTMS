using MediatR;
using SchoolManagement.Application.DTOs.ExamCenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenters.Requests.Queries
{
    public class GetExamCenterDetailRequest : IRequest<ExamCenterDto>
    {
        public int ExamCenterId { get; set; }
    }
}
 