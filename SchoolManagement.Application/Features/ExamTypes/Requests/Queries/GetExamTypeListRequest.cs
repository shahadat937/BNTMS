using MediatR;
using SchoolManagement.Application.DTOs.ExamType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamTypes.Requests.Queries
{
   public class GetExamTypeListRequest : IRequest<PagedResult<ExamTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
