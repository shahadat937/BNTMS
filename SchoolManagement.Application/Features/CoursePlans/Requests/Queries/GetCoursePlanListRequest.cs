using MediatR;
using SchoolManagement.Application.DTOs.CoursePlan;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Queries
{
   public class GetCoursePlanListRequest : IRequest<PagedResult<CoursePlanDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
