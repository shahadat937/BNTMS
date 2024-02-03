using MediatR;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries
{
   public class GetExamAttemptTypeListRequest : IRequest<PagedResult<ExamAttemptTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 