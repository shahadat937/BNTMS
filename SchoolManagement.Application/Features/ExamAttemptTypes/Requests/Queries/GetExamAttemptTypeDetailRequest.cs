using MediatR;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries
{
    public class GetExamAttemptTypeDetailRequest : IRequest<ExamAttemptTypeDto>
    {
        public int ExamAttemptTypeId { get; set; }
    }
}
 