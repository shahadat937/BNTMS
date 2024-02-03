using MediatR;
using SchoolManagement.Application.DTOs.ExamType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamTypes.Requests.Queries
{
    public class GetExamTypeDetailRequest : IRequest<ExamTypeDto>
    {
        public int ExamTypeId { get; set; }
    }
}
