using MediatR;
using SchoolManagement.Application.DTOs.CoursePlan;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Queries
{
    public class GetCoursePlanDetailRequest : IRequest<CoursePlanDto>
    {
        public int CoursePlanCreateId { get; set; }
    }
}
