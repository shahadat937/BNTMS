using MediatR;
using SchoolManagement.Application.DTOs.ExamCenter;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenters.Requests.Queries
{
   public class GetExamCenterListRequest : IRequest<PagedResult<ExamCenterDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 