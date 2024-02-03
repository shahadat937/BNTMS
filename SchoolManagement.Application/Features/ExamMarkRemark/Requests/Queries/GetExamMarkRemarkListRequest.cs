using MediatR;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries
{
   public class GetExamMarkRemarkListRequest : IRequest<PagedResult<ExamMarkRemarkDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
