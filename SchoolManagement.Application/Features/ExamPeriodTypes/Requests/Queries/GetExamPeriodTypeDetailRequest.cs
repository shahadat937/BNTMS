using MediatR;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries
{
    public class GetExamPeriodTypeDetailRequest : IRequest<ExamPeriodTypeDto>
    {
        public int ExamPeriodTypeId { get; set; }
    }
}
 