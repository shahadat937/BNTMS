using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationListBySchoolRequest: IRequest<PagedResult<CourseDurationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }

    }
}
