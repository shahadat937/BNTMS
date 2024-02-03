using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
   public class GetCourseDurationListForMistRequest : IRequest<PagedResult<CourseDurationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
