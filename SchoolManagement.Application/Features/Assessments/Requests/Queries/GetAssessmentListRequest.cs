using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Assessment;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Assessments.Requests.Queries
{
   public class GetAssessmentListRequest : IRequest<PagedResult<AssessmentDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
